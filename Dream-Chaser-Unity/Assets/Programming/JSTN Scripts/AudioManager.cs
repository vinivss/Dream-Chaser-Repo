using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    static AudioManager AMInstance;
    GameManager gameManager;
    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    private EventInstance ambienceEventInstances;
    private EventInstance musicEventInstances;

    
    public static AudioManager instance { get; private set;}

    private void Awake(){
        if(AMInstance == null)
        {
            AMInstance = this;
            DontDestroyOnLoad(AMInstance);
            gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            if (instance != null){
                Debug.LogError("Found more than one Audio Manager in scene");
            }
        instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }        
    }

    private void FixedUpdate()
    {
        //Debug.Log(gameManager.cpCount);
    }

    private void Start(){
        InitializeAmbience(FMODEvents.instance.ambience);
        InitializeMusic(FMODEvents.instance.music);
        resequenceMusic();
        DontDestroyOnLoad(this.gameObject);
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
