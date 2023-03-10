using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambience {get; private set; }
    
    [field: Header("Music")]
    [field: SerializeField] public EventReference music {get; private set; }

    [field: Header("Wind SFX")]
    [field: SerializeField] public EventReference windBlowing {get; private set; }


    public static FMODEvents instance {get; private set;}

    private void Awake(){
        if(instance != null){
            Debug.LogError("Found more than one Audio Manager in scene");
        }
        instance = this;
    }
}
