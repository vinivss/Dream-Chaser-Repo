using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gameManager;
    int pointsAtCheckpoint;
    DCMoveVin player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DCMoveVin>();
        if (player == null)
        {
            Debug.Log("cant find player");
        }
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.incrementCp();
            
            if(gameManager.lastCheckpointPosition != transform.position){
                gameManager.lastCheckpointPosition = transform.position;
                pointsAtCheckpoint = gameManager.cpPoints;
                gameManager.cpCount++;
            }        
            
        }
    }
}
