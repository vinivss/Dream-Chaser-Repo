using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// used for anything WITH A GAME MANAGER
// this ideally for the 3d Levels back into 
// the visual novel scenes.

public class LeveltoVNTransV : MonoBehaviour
{
    public string VnScene;
    GameManager Gm;
    AudioManager AudioMgr;
    private void Awake()
    {
        Gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        AudioMgr = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        ChangeScene();
    //    }
    //}
    public void ChangeScene()
    {
        DestroyImmediate(Gm);       
        DestroyImmediate(AudioMgr);
        SceneManager.LoadScene(VnScene);
    }
}
