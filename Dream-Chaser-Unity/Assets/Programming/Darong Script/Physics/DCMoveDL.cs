using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCMoveDL : MonoBehaviour
{
    //innate components gotten during Awake for functionality
    ControlsManager inManager;
    Rigidbody rb;

    //priv hidden variables
    Vector3 moveDir;

    //Inspector Vars
    [Header("Movement Attributes")]
    [Tooltip("Minimum Forward Velocity")]
    [SerializeField]float minForwardSpeed;
    [Tooltip("Maximum threshold before slowly rotating to front")]
    [SerializeField] float rotationThreshold;

    [Header("slope check")]
    public float playerHeight;
    public float maxSlopeAngle;
    public RaycastHit slopeDetected;


    private void Awake()
    {
        inManager = GetComponent<ControlsManager>();
        rb = GetComponent<Rigidbody>();
    }

    //physics management
    private void FixedUpdate()
    {
        onSlope();
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Debug.DrawRay(transform.position, -transform.forward, Color.blue);

        moveDir = new Vector3(inManager.GetMoveValue().x + transform.forward.x, 0 , inManager.GetMoveValue().y + transform.forward.z);
       
        transform.forward = moveDir;

        rb.AddForce((moveDir * minForwardSpeed) + Physics.gravity, ForceMode.Acceleration);
       


    }

    private bool onSlope()
    {
        //Debug.Log("check on slope");
        if (Physics.Raycast(transform.position, Vector3.down, out slopeDetected, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeDetected.normal);
            //Debug.Log("on slope");
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;

    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDir, slopeDetected.normal).normalized;
    }


}
