using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [Tooltip("Total points player has earned this level")]
    public int pointsTotal;

    public void AddPoints(int pointsToAdd)
    {
        pointsTotal += pointsToAdd;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
