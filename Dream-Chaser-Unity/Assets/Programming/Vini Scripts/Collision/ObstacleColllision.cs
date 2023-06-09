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
        Debug.Log(this.tag + " " + other.tag);
        if (this.tag != "Collectible") {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ambience, this.transform.position);
            Debug.Log(other.tag);
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
