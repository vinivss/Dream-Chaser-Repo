using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionTrigger : MonoBehaviour
{
    [Tooltip("Event That will be activated ontrigger enter")]
    public UnityEvent TriggerEvent;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TriggerEvent.Invoke();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
