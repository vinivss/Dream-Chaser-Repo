using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleColllision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ResetScene());
    }

    IEnumerator ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return null;
    }
}
