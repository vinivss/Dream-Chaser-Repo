using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GenericTransV : MonoBehaviour
{
    public Scene GenScene;


    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene(GenScene.name);
    }
}
