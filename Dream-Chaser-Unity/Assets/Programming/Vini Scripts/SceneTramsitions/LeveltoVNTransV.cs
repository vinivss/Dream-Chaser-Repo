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
    public Object VnScene;
    GameManager Gm;
    private void Awake()
    {
        Gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    public void ChangeScene()
    {
        DestroyImmediate(Gm);
        SceneManager.LoadScene(VnScene.name);
    }
}
