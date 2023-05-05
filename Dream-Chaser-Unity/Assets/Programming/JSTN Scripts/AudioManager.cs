using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
//    static AudioManager AMInstance;
    GameManager gameManager;
    pause_scene pause;
    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    private EventInstance ambienceEventInstances;
    private EventInstance musicEventInstances;
    private EventInstance sfxEventInstances;
    
    public static AudioManager instance { get; private set;}

    private void Awake(){
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            if (instance != null){
                //Debug.LogError("Found more than one Audio Manager in scene");
            }
        }
        else
        {
            DestroyImmediate(gameObject);
        }        
    }

    private void FixedUpdate()
    {
        //Level Complete
        if(gameManager.cpCount >= 6){
            ambienceEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            InitializeMusic(FMODEvents.instance.vnOST);
            gameManager.cpCount = 0;
        }
        resequenceMusic();

        //Pause Fade out
        if(Input.GetKeyDown(KeyCode.Escape) && pause.pauseFlag) {
            // Code to execute when Escape key is pressed
            Debug.Log("Initiate Pause");
        } else if(Input.GetKeyDown(KeyCode.Escape) && !pause.pauseFlag) {
            Debug.Log("Exit Pause");
        }

    }

    private void Start(){
        InitializeAmbience(FMODEvents.instance.ambience);
        InitializeMusic(FMODEvents.instance.levelMusic);
        //InitializeSFX(FMODEvents.instance.reset);
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

    /*public void Stop(EventInstance Event,bool Fade)
    {
        if(Fade)
        {
            Event.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        else
        {
            Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        }
        
    }*/
}
