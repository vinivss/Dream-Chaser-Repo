using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this is meant for any scenes WITHOUT A GAME MANAGER
// IE: any of the visual novel scenes.


public class GenericTransV : MonoBehaviour
{
    public string GenScene;
    public GameObject LoadingScreen;
    VNAudioManager VNaudio;

    public static GenericTransV instance { get; private set;}
    // Update is called once per frame
    public void Awake()
    {

    }
    public void ChangeScene()
    {
        //VNaudio.musicEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        StartCoroutine(LoadSceneAsync());


    }
    IEnumerator LoadSceneAsync()
    {
        LoadingScreen = Instantiate(LoadingScreen, GameObject.FindObjectOfType<Canvas>().transform);
        AsyncOperation op = SceneManager.LoadSceneAsync(GenScene);
        while (!op.isDone)
        {
            yield return null;
        }
        if(op.isDone)
        StopAllCoroutines();
        
    }
}
