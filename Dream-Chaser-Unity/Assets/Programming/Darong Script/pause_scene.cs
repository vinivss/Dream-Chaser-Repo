using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class pause_scene : MonoBehaviour
{
    public AudioManager audio;
    public GameObject pauseMenu;
    public bool pauseFlag;
    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        pauseFlag = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseFlag)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public bool getPauseState(bool paused){
        pauseFlag = paused;
        return paused;
    }

    public void pause()
    {
        audio.Pause();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseFlag = true;
        audio.musicEventInstances.setParameterByName("pause", 1);
    }

    public void resume()
    {
        audio.Resume();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseFlag = false;
        audio.musicEventInstances.setParameterByName("pause", 0);
    }
}
