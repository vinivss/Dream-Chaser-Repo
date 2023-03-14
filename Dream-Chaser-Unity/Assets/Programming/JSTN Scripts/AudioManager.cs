using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    GameManager gameManager;
    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    private EventInstance ambienceEventInstances;
    private EventInstance musicEventInstances;

    
    public static AudioManager instance { get; private set;}

    private void Awake(){
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        if (instance != null){
            Debug.LogError("Found more than one Audio Manager in scene");
        }
        instance = this;
    }

    private void FixedUpdate()
    {
        Debug.Log(gameManager.cpCount);
    }

    private void Start(){
        InitializeAmbience(FMODEvents.instance.ambience);
        InitializeMusic(FMODEvents.instance.music);
        resequenceMusic();
    }

    private void InitializeAmbience(EventReference ambienceEventReference){
        ambienceEventInstances = CreateInstance(ambienceEventReference);
        ambienceEventInstances.start();
    }

    private void InitializeMusic(EventReference musicEventReference){
        musicEventInstances = CreateInstance(musicEventReference);
        musicEventInstances.start();
    }

    private void resequenceMusic(){
        musicEventInstances.setParameterByName("checkpoint", gameManager.cpCount);
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
