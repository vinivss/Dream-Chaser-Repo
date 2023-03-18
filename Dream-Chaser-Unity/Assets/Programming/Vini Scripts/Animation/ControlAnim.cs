using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnim : MonoBehaviour
{
    Animator anim;
    DCMoveVin Player;
    float currSpeed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<DCMoveVin>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        currSpeed = Player.rb.velocity.magnitude / Player.maxSpeed;
        anim.SetFloat("Speed", currSpeed);

    }
}
