using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using FMOD.Studio;

public class DCMoveVin : MonoBehaviour
{
    //innate components gotten during Awake for functionality
    ControlsManager inManager;
    Rigidbody rb;

    //priv hidden variables
    Vector3 moveDir;
    float velo;

    //Inspector Vars
    [Header("Movement Attributes")]
    [Tooltip("Minimum Forward Velocity")]
    [SerializeField] float minForwardSpeed;
    [Tooltip("Maximum threshold before slowly rotating to front")]
    [SerializeField] float rotationThreshold;
    [Tooltip("Max Speed you can accelerate to")]
    [Min(0.0f)]public float maxSpeed;

    //audio inspector vars
    [Header("Audio Attributes")]
    [Tooltip("The name of the FMOD Parameter function")]
    [SerializeField]  string parameterName;

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

        if(rb.velocity.magnitude > 0.01f && rb.velocity.magnitude != 0)
        { 
            StartCoroutine(StopMove());
            
        }

    }   
    IEnumerator StopMove()
    {
        inManager.OnDisable();
        yield return new WaitForSeconds(0.5f);
        inManager.OnEnable();
    }

    private void UpdateSound(){
        velo = rb.velocity.magnitude/maxSpeed*4;
        AudioManager.instance.SetAmbienceParameter(parameterName, velo);
    }
}
