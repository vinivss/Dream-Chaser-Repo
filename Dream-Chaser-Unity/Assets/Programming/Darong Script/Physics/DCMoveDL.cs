using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCMoveDL : MonoBehaviour
{
    //innate components gotten during Awake for functionality
    ControlsManager inManager;

    //Inspector Vars
    [Header("Movement Attributes")]
    [Tooltip("Minimum Forward Velocity")]
    [SerializeField] float minForwardSpeed;
    [Tooltip("Maximum threshold before slowly rotating to front")]
    [SerializeField] float rotationThreshold;

    [SerializeField] Transform groundCheck;

    public float drag_force;

    [Header("Platform")]
    public LayerMask GroundPlatform;
    public LayerMask SlopePlatform;
    
    bool slope;

    [Header("Ground check")]
    public bool grounded = false;
    public float playerHeight;

    [Header("slope check")]
    public float maxSlopeAngle;
    public RaycastHit slopeDetected;

    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDir;
    Rigidbody rb;





    private void Awake()
    {

        inManager = GetComponent<ControlsManager>();

        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;                       // freeze at T pose

    }
    private void Update()
    {
        myInput();

        SpeedControl();
    }

    //physics management
    private void FixedUpdate()
    {
        GetSlopeMoveDirection();
        MoveCharacter();
    }

    // basic movement key
    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MoveCharacter()
    {
        /*  vini movement
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Debug.DrawRay(transform.position, -transform.forward, Color.blue);

        moveDir = new Vector3(inManager.GetMoveValue().x + transform.forward.x, 0 , inManager.GetMoveValue().y + transform.forward.z);
       
        transform.forward = moveDir;

        rb.AddForce((moveDir * minForwardSpeed) + Physics.gravity, ForceMode.Acceleration);
        */

        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
        rb.AddForce((moveDir * minForwardSpeed) + Physics.gravity, ForceMode.Acceleration);


        // keep adding speed if on slope
        if (onSlope())
        {
            Debug.Log("on slope");
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);
        }

        rb.useGravity = !onSlope();

    }

    // slope detection (DL)
    private bool onSlope()
    {

        if (Physics.Raycast(transform.position, Vector3.down, out slopeDetected, playerHeight * 0.5f + 0.3f))   // shooting a ray from to the down to the platform
        {
            float angle = Vector3.Angle(Vector3.up, slopeDetected.normal);                                      // get the angle from vector 3
            return angle < maxSlopeAngle && angle != 0;                                                         // compare with the max angle
        }

        return false;

    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDir, slopeDetected.normal).normalized;
    }

    private void SpeedControl()
    {
        
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // get current velocity

        // fix velocity if above the limit
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }

    // coeffient

}
