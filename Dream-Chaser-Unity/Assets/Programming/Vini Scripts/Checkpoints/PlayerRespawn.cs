using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        if(gameManager.sceneStarted)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.reset, this.transform.position);
            transform.position = gameManager.lastCheckpointPosition;
        }
        else
        {
            gameManager.sceneStarted = true;
        }
    }
}
