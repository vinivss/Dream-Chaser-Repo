using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTransfer : MonoBehaviour
{
    public void TransferScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
