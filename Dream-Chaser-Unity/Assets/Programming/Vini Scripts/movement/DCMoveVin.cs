using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField]float minForwardSpeed;
    [Tooltip("Maximum threshold before slowly rotating to front")]
    [SerializeField] float rotationThreshold;

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

        moveDir = new Vector3(inManager.GetMoveValue().x + transform.forward.x, 0 , inManager.GetMoveValue().y + transform.forward.z);
        if (moveDir != Vector3.zero) 
        transform.forward = moveDir;  

        if(rb.velocity != Vector3.zero)
        rb.AddForce(transform.forward * minForwardSpeed + Physics.gravity, ForceMode.Acceleration);


    }
}
