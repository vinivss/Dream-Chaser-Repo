using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambience {get; private set; }
    
    [field: Header("Music")]
    [field: SerializeField] public EventReference levelMusic {get; private set; }

    [field: Header("Reset SFX")]
    [field: SerializeField] public EventReference reset {get; private set; }

    [field: Header("VN Theme")]
    [field: SerializeField] public EventReference vnOST {get; private set; }
    
    [field: Header("Pause SFX")]
    [field: SerializeField] public EventReference pause {get; private set; }
    
    [field: Header("Resume SFX")]
    [field: SerializeField] public EventReference resume {get; private set; }

    public static FMODEvents instance {get; private set;}

    private void Awake(){
        if(instance != null){
            //Debug.LogError("Found more than one Audio Manager in scene");
        }
        instance = this;
    }
}
