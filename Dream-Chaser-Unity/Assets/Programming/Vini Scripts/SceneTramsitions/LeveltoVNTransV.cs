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
    public GameObject LoadingScreen;
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
        Gm.sceneStarted = false;
        //DestroyImmediate(Gm);
        DestroyImmediate(AudioMgr);
        AudioMgr.thanos();
        StartCoroutine(LoadSceneAsync());
    }
    IEnumerator LoadSceneAsync()
    {
        LoadingScreen = Instantiate(LoadingScreen);
        AsyncOperation op = SceneManager.LoadSceneAsync(VnScene);
        while(!op.isDone)
        {
            yield return null;
        }
    }
}
