using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    private EventInstance ambienceEventInstances;
    
    public static AudioManager instance { get; private set;}

    private void Awake(){
        if (instance != null){
            Debug.LogError("Found more than one Audio Manager in scene");
        }
        instance = this;
    }

    private void Start(){
        InitializeAmbience(FMODEvents.instance.ambience);
    }

    private void InitializeAmbience(EventReference ambienceEventReference){
        ambienceEventInstances = CreateInstance(ambienceEventReference);
        ambienceEventInstances.start();
    }

    public void SetAmbienceParameter(string parameterName, float parameterValue){
        ambienceEventInstances.setParameterByName(parameterName, parameterValue);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos){
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
