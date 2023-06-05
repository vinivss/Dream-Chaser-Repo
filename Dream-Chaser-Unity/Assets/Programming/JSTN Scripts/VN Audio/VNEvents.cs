using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class VNEvents : MonoBehaviour
{
    [field: Header("SFX")]
    [field: SerializeField] public EventReference sfx {get; private set; }
    
    [field: Header("Music")]
    [field: SerializeField] public EventReference music {get; private set; }

    public static VNEvents instance {get; private set;}

    private void Awake(){
        if(instance != null){
            //Debug.LogError("Found more than one Audio Manager in scene");
        }
        instance = this;
    }
}
