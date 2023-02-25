using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class DCMoveVin : MonoBehaviour
{
    //innate components gotten during Awake for functionality
    ControlsManager inManager;
    Rigidbody rb;

    //priv hidden variables
    Vector3 moveDir;

    //Inspector Vars
    [Header("Movement Attributes")]
    [Tooltip("Minimum Forward Velocity")]
    [SerializeField] float minForwardSpeed;
    [Tooltip("Maximum threshold before slowly rotating to front")]
    [SerializeField] float rotationThreshold;
    [Tooltip("Max Speed you can accelerate to")]
    [Min(0.0f)]public float maxSpeed;

    
    private void Awake()
    {
        inManager = GetComponent<ControlsManager>();
        rb = GetComponent<Rigidbody>();
    }

    //physics management
    private void FixedUpdate()
    {
        MoveCharacter();
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
            Debug.Log("Penis");      
            StartCoroutine(StopMove());
            
        }

    }   
    IEnumerator StopMove()
    {
        inManager.OnDisable();
        yield return new WaitForSeconds(0.5f);
        inManager.OnEnable();
    }
}
