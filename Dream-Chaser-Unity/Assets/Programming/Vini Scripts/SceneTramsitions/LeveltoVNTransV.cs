using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeveltoVNTransV : MonoBehaviour
{
    public Scene VnScene;
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
