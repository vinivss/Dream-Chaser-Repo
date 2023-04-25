using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set Moon shader to be in the position of the main direct light
        Shader.SetGlobalVector("_MoonDirection", transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
