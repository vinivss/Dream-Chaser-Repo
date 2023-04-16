using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class CharacterControls : MonoBehaviour
{

    Animator animator;

    //movement Parameters
    [Space]
    [Header("Movement")]
    public float moveSpeed = 6f;
    float movementMultiplier = 10f;
    //private
    Vector3 moveDir;
    Rigidbody rb;
    ControlsManager  inputs;
    Vector2 currentMove;
    private Vector3 slopeMoveDir;
    private RaycastHit slopeHit;
    float playerHeight = 2f;
    Vector2 LastDir;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        inputs = GetComponent<ControlsManager>();

    }

    private void LateUpdate()
    {
        HandleAnimation();
    }


    private void FixedUpdate()
    {
        MoveCharacter();
    }


    private void HandleAnimation()
    {
        if (currentMove == Vector2.zero)
        {
            animator.SetBool("Moving", false);       
        }

        else
        {
            animator.SetFloat("movX", currentMove.x);
            animator.SetFloat("movY", currentMove.y);
            animator.SetBool("Moving", true);

        }

        slopeMoveDir = Vector3.ProjectOnPlane(moveDir, slopeHit.normal);
    }
    private void MoveCharacter()
    {
        currentMove = inputs.GetMoveValue();
        if (currentMove == Vector2.zero)
        {

        }
        moveDir = new Vector3(currentMove.x, 0, currentMove.y);
        

        if(!OnSlope())
        {
            rb.AddForce(moveDir * moveSpeed * movementMultiplier, ForceMode.Acceleration);    
        }
        else
        {
            rb.AddForce(moveDir *moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }


    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.05f))
        {
            if(slopeHit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }
}
