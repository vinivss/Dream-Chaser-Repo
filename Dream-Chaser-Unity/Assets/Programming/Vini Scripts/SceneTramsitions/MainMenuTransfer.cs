using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class MainMenuTransfer : MonoBehaviour
{
    MenuAudioManager menuAudio;
    public GameObject LoadingScreen;
    public string Scene;
    private void Awake()
    {
        menuAudio = FindObjectOfType<MenuAudioManager>();
    }
    public void TransferScene(string SceneName)
    {
        if (menuAudio != null)
        {
            menuAudio.ambienceEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            menuAudio.musicEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            DestroyImmediate(menuAudio);
        }
       StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        LoadingScreen = Instantiate(LoadingScreen, GameObject.FindObjectOfType<Canvas>().transform);
        AsyncOperation op = SceneManager.LoadSceneAsync(Scene);
        while (!op.isDone)
        {
            yield return null;
        }
    }
}
