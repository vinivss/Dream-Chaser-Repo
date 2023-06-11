using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointIndex : MonoBehaviour
{
    [SerializeField] public int totalCheckpoints;
    private int currentIndex;
    private bool finishLevel = false;

    public int currentCheckpoint()
    {
        return currentIndex;
    }

    public void arriveCheckpoint()
    {
        if (totalCheckpoints > currentIndex)
        {
            currentIndex += 1;
        }
        else
        {
            finishLevel = true;
        }
        Debug.Log(currentIndex);
    }

    public bool isFinish()
    {
        return finishLevel;
    }
}
