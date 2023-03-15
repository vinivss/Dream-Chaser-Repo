using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using FMOD.Studio;
using System;
using UnityEngine.Events;

public class DCMoveVin : MonoBehaviour
{
    //innate components gotten during Awake for functionality
    ControlsManager inManager;
    Rigidbody rb;

    //priv hidden variables
    Vector3 moveDir;
    float velo;
    float jumpforce = 0;
    bool jumping;
    bool isGrounded;

    //Inspector Vars
    [Header("Movement Attributes")]
    [Tooltip("Minimum Forward Velocity")]
    [SerializeField] float minForwardSpeed;
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
    //audio inspector vars
    [Header("Audio Attributes")]
    [Tooltip("The name of the FMOD Parameter function")]
    public  UnityEvent parameterName;

    private void Awake()
    {
        inManager = GetComponent<ControlsManager>();
        rb = GetComponent<Rigidbody>();
    }

    //physics management
    private void FixedUpdate()
    {
        MoveCharacter();
        UpdateSound();
    }

    private void MoveCharacter()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Debug.DrawRay(transform.position, -transform.forward, Color.blue);

        moveDir = new Vector3(inManager.GetMoveValue().x + transform.forward.x, 0, inManager.GetMoveValue().y + transform.forward.z);
        if(moveDir != Vector3.zero)
        transform.forward = moveDir;

        rb.AddForce((moveDir * minForwardSpeed) + Physics.gravity, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed* 100);

        //if(rb.velocity.magnitude > 0.01f && rb.velocity.magnitude != 0)
        //{ 
        //    StartCoroutine(StopMove());           
        //}
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
        CheckGround();
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

    IEnumerator StopMove()
    {
        inManager.OnDisable();
        yield return new WaitForSeconds(0.5f);
        inManager.OnEnable();
    }

    private void UpdateSound(){
        velo = rb.velocity.magnitude/maxSpeed*4;
        AudioManager.instance.SetAmbienceParameter("wind_intensity", velo);
    }
}
