using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager managerInstance;

    public int cpPoints;
    int pointsTotal;
    public Vector3 lastCheckpointPosition;
    public float cpCount;
    

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
        pointsTotal = cpPoints;
    }

    private void Start()
    {
    }

    public void AddPoints(int pointsToAdd)
    {
        pointsTotal += pointsToAdd;
    }
}
