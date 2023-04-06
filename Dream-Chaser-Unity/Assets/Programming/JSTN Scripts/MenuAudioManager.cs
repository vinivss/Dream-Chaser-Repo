using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;

public class MenuAudioManager : MonoBehaviour
{
//    static AudioManager AMInstance;
    SubEventTimes subEventTimes;

    private EventInstance eventInstance;
    private EventInstance testInstance;

    private EventDescription musicDescription;
    private EventDescription eventDescription;

    public float subEventLength;
    private float fadeOut;


    private EventInstance ambienceEventInstances;
    private EventInstance musicEventInstances;
    float parameterCount;
    
    public static MenuAudioManager instance { get; private set;}

    private void Awake(){
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            subEventTimes = FindObjectOfType<SubEventTimes>().GetComponent<SubEventTimes>();
            if (instance != null){
                //Debug.LogError("Found more than one Audio Manager in scene");
            }
        }
        else
        {
            DestroyImmediate(gameObject);
        }        
    }

    private void Start(){
        fadeOut = 12;
        parameterCount = 0;
        InitializeAmbience(MenuEvents.instance.ambience);
        InitializeMusic(MenuEvents.instance.menuMusic);
    }

    private void FixedUpdate()
    {
        getTime();
    }

    //gets the current time in the track
    private void getTime(){
        float length;
        float newNum;
        if (musicEventInstances.isValid()){
            length = subEventTimes.getSubTime(parameterCount);
            int timelinePosition;
            musicEventInstances.getTimelinePosition(out timelinePosition);
            float currentTime = (float)timelinePosition / 1000.0f;
            //Debug.Log("Current time in sub-event: " + currentTime);
            //Debug.Log(length);
            if(currentTime >= length - fadeOut){
                musicEventInstances.setTimelinePosition(0);
                newNum = Random.Range(0f,9f);
                if(parameterCount != newNum){
                    newNum = Random.Range(0f,9f);
                }                    
                SetMusic(newNum);
                length = subEventTimes.getSubTime(newNum);
                parameterCount = newNum;
            }                        
        }
    }
    
    private void plskillme(){
/*        subEventInstances = musicDescription.getInstances();
        foreach (EventInstance subEventInstance in subEventInstances){
            float length = subEventInstance.getTimelineLength();
            Debug.Log("Subevent length: " + length);
        }
*/
    }

    //initializes the looping background noise
    private void InitializeAmbience(EventReference ambienceEventReference){
        ambienceEventInstances = CreateInstance(ambienceEventReference);
        ambienceEventInstances.start();
    }

    //initializes the music event
    private void InitializeMusic(EventReference musicEventReference){
        musicEventInstances = CreateInstance(musicEventReference);
        musicEventInstances.getDescription(out musicDescription);
        musicEventInstances.start();
    }

    //traverses to the new subevent chosen from paramNum
    public void SetMusic(float paramNum){
        musicEventInstances.setParameterByName("Menu", paramNum);
    }

    // simple play in one go
    public void PlayOneShot(EventReference sound, Vector3 worldPos){
        RuntimeManager.PlayOneShot(sound, worldPos);
    }


    private void StopEvent()
    {
        // Stop the event
        musicEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public EventInstance CreateInstance(EventReference eventReference){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
