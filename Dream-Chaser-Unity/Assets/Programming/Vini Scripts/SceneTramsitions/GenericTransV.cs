using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this is meant for any scenes WITHOUT A GAME MANAGER
// IE: any of the visual novel scenes.


public class GenericTransV : MonoBehaviour
{
    public Object GenScene;
    public GameObject LoadingScreen;

    // Update is called once per frame
    public void ChangeScene()
    {
        StartCoroutine(LoadSceneAsync());
    }
    IEnumerator LoadSceneAsync()
    {
        LoadingScreen = Instantiate(LoadingScreen, GameObject.FindObjectOfType<Canvas>().transform);
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!op.isDone)
        {
            yield return null;
        }
    }
}
