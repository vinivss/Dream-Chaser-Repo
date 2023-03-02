using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    Vector2 InputValue;
    Inputs input;

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
    }

    public Vector2 GetMoveValue()
    {
        return InputValue;
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
