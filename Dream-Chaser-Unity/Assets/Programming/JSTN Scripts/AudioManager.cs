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
    DCMoveVin controls;
    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    private EventInstance ambienceEventInstances;
    public EventInstance musicEventInstances;
    
    private EventInstance pauseEventInstances;
    private EventInstance resumeEventInstances;
    
    public static AudioManager instance { get; private set;}

    private void Awake(){
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            if(gameManager != null)
            { 
            gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            }
            pause = FindObjectOfType<pause_scene>();
            controls = FindObjectOfType<DCMoveVin>();
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
        if (gameManager != null)
        {
            if (gameManager.cpCount >= 6)
            {
                ambienceEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                musicEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                InitializeMusic(FMODEvents.instance.vnOST);
                gameManager.cpCount = 0;
            }
        }
        resequenceMusic();
        if(Input.GetKeyDown(KeyCode.Space) /*&& controls.isGrounded*/){
            RuntimeManager.PlayOneShot("event:/SFX/Jump", this.transform.position);
        }
    }

    private void Start(){
        InitializeAmbience(FMODEvents.instance.ambience);
        InitializeMusic(FMODEvents.instance.levelMusic);        
        InitializeSFX(FMODEvents.instance.pause, FMODEvents.instance.resume);
        resequenceMusic();
        DontDestroyOnLoad(this.gameObject);
    }

    private void InitializeAmbience(EventReference ambienceEventReference){
        ambienceEventInstances = CreateInstance(ambienceEventReference);
        ambienceEventInstances.start();
    }

    private void InitializeSFX(EventReference pauseEventReference, EventReference resumeEventReference){
        pauseEventInstances = CreateInstance(pauseEventReference);
        resumeEventInstances = CreateInstance(resumeEventReference);
    }

    private void InitializeMusic(EventReference musicEventReference){
        musicEventInstances = CreateInstance(musicEventReference);
        musicEventInstances.start();
    }

    private void resequenceMusic(){
        if(gameManager != null)
        musicEventInstances.setParameterByName("checkpoint", gameManager.cpCount);
    }

    public void SetAmbienceParameter(string parameterName, float parameterValue){
        ambienceEventInstances.setParameterByName(parameterName, parameterValue);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos){
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void Pause()
    {
        resumeEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);        
        pauseEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        pauseEventInstances.start();
        musicEventInstances.setParameterByName("pause", 1);
    }
    
    public IEnumerator Resume()
    {
        pauseEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        resumeEventInstances.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        resumeEventInstances.start();
        yield return new WaitForSeconds(1.0f);
        musicEventInstances.setParameterByName("pause", 0);
    }

    public float Timer(float start, float delay){ //returns the percentage of timer complete
        float endTime = start + delay;
        if(delay > start){
            return Time.time/endTime;
        }else{
            return 0f;
        }
    }

    public void killAudioManager(){
        resumeEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);        
        pauseEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musicEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);        
        ambienceEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        DestroyImmediate(gameObject);
    }

    public EventInstance CreateInstance(EventReference eventReference){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
