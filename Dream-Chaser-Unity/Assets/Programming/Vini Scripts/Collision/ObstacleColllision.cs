using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleColllision : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    PlayerHealth player_hp;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        player_hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.tag != "Collectible" || !player_hp.healthCheck()) {
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
