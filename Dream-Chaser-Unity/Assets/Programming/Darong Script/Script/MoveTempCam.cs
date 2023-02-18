using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTempCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
