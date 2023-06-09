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
        if (gameManager.sceneStarted)
        {
            transform.position = gameManager.lastCheckpointPosition;
            transform.position = new Vector3(transform.position.x, transform.position.y+50, transform.position.z);
        }
        else
        {
            gameManager.sceneStarted = true;
        }
    }
}
