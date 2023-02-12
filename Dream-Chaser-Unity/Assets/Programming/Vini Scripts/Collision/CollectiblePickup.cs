using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickup : MonoBehaviour
{

    public int pointsWorth;
    
    PointsManager pointsManager;

    private void Awake()
    {
        pointsManager = FindObjectOfType<PointsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pointsManager.AddPoints(pointsWorth);
            Destroy(gameObject);
        }
    }
}
