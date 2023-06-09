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
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!op.isDone)
        {
            yield return null;
        }
    }
}
