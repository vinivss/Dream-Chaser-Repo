using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class MainMenuTransfer : MonoBehaviour
{
    MenuAudioManager menuAudio;
    private void Awake()
    {
        menuAudio = FindObjectOfType<MenuAudioManager>().GetComponent<MenuAudioManager>();
    }
    public void TransferScene(string SceneName)
    {    
        menuAudio.ambienceEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        menuAudio.musicEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        DestroyImmediate(menuAudio);
        SceneManager.LoadScene(SceneName);
    }
}
