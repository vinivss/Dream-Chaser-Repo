using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using FMOD.Studio;
using System;
using UnityEngine.Events;
using Cinemachine;

public class DCMoveVin : MonoBehaviour
{
    //innate components gotten during Awake for functionality
    ControlsManager inManager;
    [HideInInspector]public Rigidbody rb;

    //priv hidden variables
    Vector3 moveDir;
    float velo;
    float jumpforce = 0;
    bool jumping;
    bool isGrounded;
    CinemachineVirtualCamera Cam;
    float startFOV;
    OnDeathDissolve DissolveScript;

    //Inspector Vars
    [Header("Movement Attributes")]
    [Tooltip("Minimum Forward Velocity")]
    [SerializeField] float minForwardSpeed;
    [SerializeField] float deceleration;
    [Tooltip("Maximum threshold before slowly rotating to front")]
    [SerializeField] float rotationThreshold;
    [Tooltip("Max Speed you can accelerate to")]
    [Min(0.0f)]public float maxSpeed;
    [Tooltip("Jump Force Min Value")]
    [Min(0.0f)] public float minJump;
    [Tooltip("Maximum Jump Force")]
    public float maxJump;
    [Tooltip("Ground Check Sphere")]
    public Transform groundCheckPos;
    [Min(0)]
    [Tooltip("Radius of Sphere used in ground detection")]
    [SerializeField] float groundDistance = 0.4f;
    [Tooltip("layer for ground to be detected")]
    [SerializeField] LayerMask groundMask;
    [Tooltip("Air Heavy stuff")]
    [SerializeField] float airDrag;
    [Tooltip("Normal heavy stuff")]
    [SerializeField] float normDrag;
    [Tooltip("DC Model")]
    [SerializeField] float turnSpeed;
    [Tooltip("Player Height")]
    [SerializeField] float height;



    //audio inspector vars
    [Header("Audio Attributes")]
    [Tooltip("The name of the FMOD Parameter function")]
    public  UnityEvent parameterName;

    private void Awake()
    {
        inManager = GetComponent<ControlsManager>();
        rb = GetComponent<Rigidbody>();
        Cam = FindObjectOfType<CinemachineVirtualCamera>();
        //startFOV = Cam.m_Lens.FieldOfView;
        DissolveScript = GetComponent<OnDeathDissolve>();
    }

    //physics management
    private void FixedUpdate()
    {
        if (rb != null)
        {
            MoveCharacter();
            CheckGround();
            if (!isGrounded)
            {

                rb.drag = airDrag;
            }
            else
            {
                //Debug.Log("on ground");
                rb.drag = normDrag;
            }
        }
        UpdateSound();
    }

    private void MoveCharacter()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Debug.DrawRay(transform.position, -transform.forward, Color.blue);

     
        if (moveDir != Vector3.zero)
        {
            Quaternion rotGoal =Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
        }

        //moveDir = new Vector3(inManager.GetMoveValue().x + transform.forward.x, 0, Mathf.Clamp(inManager.GetMoveValue().y + transform.forward.z, 0.5f, 1.0f));
        //rb.AddForce((moveDir * minForwardSpeed) + Physics.gravity, ForceMode.Acceleration);
        
        if (inManager.GetMoveValue().y < 0)
        {
            moveDir = new Vector3(inManager.GetMoveValue().x , 0, Mathf.Clamp(inManager.GetMoveValue().y + transform.forward.z, 0.5f, 1.0f));
            rb.AddForce((moveDir * deceleration) + Physics.gravity, ForceMode.Acceleration);
            Vector3 v = rb.velocity;
            v.z = Mathf.Clamp(v.z, minForwardSpeed, maxSpeed);
            rb.velocity = v;
        }
        else
        {
            moveDir = new Vector3(inManager.GetMoveValue().x + transform.forward.x, 0, Mathf.Clamp(inManager.GetMoveValue().y + transform.forward.z, 0.5f, 1.0f));
            rb.AddForce((moveDir * minForwardSpeed) + Physics.gravity, ForceMode.Acceleration);            
        }


        FixBouncing();
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        //Cam.m_Lens.FieldOfView = Mathf.Clamp(rb.velocity.z, startFOV, 95.0f);
        JumpPerformed();
    }

    private void JumpPerformed()
    {
        if(inManager.JumpPerformed())
        {
            jumping = true;
            if(jumpforce == 0)
            jumpforce += minJump;

            jumpforce += Time.deltaTime;
        }
        else if(jumping == true && !inManager.JumpPerformed() && isGrounded == true)
        {           
            rb.AddForce(Vector3.up * Mathf.Clamp(jumpforce, minJump, maxJump), ForceMode.Impulse);
            jumping = false;
            jumpforce = 0;
        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPos.position, groundDistance);
    }
    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheckPos.position, groundDistance, groundMask);
    }

    private void UpdateSound(){
        velo = rb.velocity.magnitude/maxSpeed*4;
        AudioManager.instance.SetAmbienceParameter("wind_intensity", velo);
    }

    public void PlayerDeath()
    {
        rb.isKinematic = true;
        inManager.OnDisable();
        DissolveScript.OnPlayerDeath();
    }

    private void FixBouncing()
    {

        if (!jumping && !isGrounded)
        {
            //Debug.Log("bouncing");

            var ray = new Ray(transform.position, Vector3.down);

            Physics.Raycast(ray, out RaycastHit hitInfo, 0.5f);

            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            var adjustedVelocity = slopeRotation * rb.velocity;

            rb.velocity = adjustedVelocity;
            

        }

    }
}
