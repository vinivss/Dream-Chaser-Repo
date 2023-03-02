using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    Vector2 InputValue;
    Inputs input;
    bool AcceptPerformed = false;

    private void Awake()
    {
        input = new Inputs();

        input.Movement.Move.performed += ctx =>
        {
            InputValue = ctx.ReadValue<Vector2>();
        };
        input.Movement.Move.canceled += ctx =>
        {
            InputValue = Vector2.zero;
        };
        input.Interacts.Accept.performed += ctx =>
        {
            AcceptPerformed = true;
        };
        input.Interacts.Accept.canceled += ctx =>
        {
            AcceptPerformed = false;
        };
    }

    public Vector2 GetMoveValue()
    {
        return InputValue;
    }
    public bool GetAcceptValue()
    {
        return AcceptPerformed;
    }
    public void OnEnable()
    {
        input.Enable();
    }
    public void OnDisable()
    {
        input.Disable();
    }

}
