using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_scene : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pauseFlag = false;
    // Start is called before the first frame update
    void Start()
    {
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

    public void pause()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseFlag = true;
    }

    public void resume()
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseFlag = false;
    }
}
