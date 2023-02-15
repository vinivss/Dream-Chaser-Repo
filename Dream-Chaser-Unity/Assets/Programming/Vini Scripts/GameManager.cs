using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager managerInstance;

    int pointsTotal;
    public Vector3 lastCheckpointPosition;

    public bool sceneStarted = false;
    private void Awake()
    {
        if(managerInstance == null)
        {
            managerInstance = this;
            DontDestroyOnLoad(managerInstance);
        }
        else
        {
            DestroyImmediate(gameObject);
        }

    }

    private void Start()
    {
    }

    public void AddPoints(int pointsToAdd)
    {
        pointsTotal += pointsToAdd;
    }
}
