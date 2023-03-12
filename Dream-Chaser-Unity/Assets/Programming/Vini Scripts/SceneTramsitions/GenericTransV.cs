using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this is meant for any scenes WITHOUT A GAME MANAGER
// IE: any of the visual novel scenes.


public class GenericTransV : MonoBehaviour
{
    public Object GenScene;


    // Update is called once per frame
    public void ChangeScene()
    {
        SceneManager.LoadScene(GenScene.name);
    }
}
