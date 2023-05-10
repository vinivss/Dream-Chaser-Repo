using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleColllision : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.tag != "Collectible") {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ambience, this.transform.position);
            FindObjectOfType<DCMoveVin>().PlayerDeath();
            StartCoroutine(ResetScene());
        }
    }

    IEnumerator ResetScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
