using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwopointFiveDinteractionVin : MonoBehaviour
{
    [Header("Interaction Variables")]
    [Tooltip("Notice of available Interaction")]public GameObject InteractBubble;
    [Tooltip("What witl this interaction do?")] public UnityEvent InteractionEvent;
    CharacterControls Player;
    bool isIn;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<CharacterControls>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isIn = true;
            InteractBubble.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isIn = false;
            InteractBubble?.SetActive(false);
        }
    }
    private void LateUpdate()
    {
        if(isIn == true)
        {
            if(Player.interact == true)
            {
                InteractionEvent.Invoke();
            }
        }
    }
}
