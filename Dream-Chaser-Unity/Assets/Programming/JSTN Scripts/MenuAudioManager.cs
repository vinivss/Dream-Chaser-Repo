using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;

public class MenuAudioManager : MonoBehaviour
{
//    static AudioManager AMInstance;
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
            //gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
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
        musicEventInstances.start();
    }

    private void FixedUpdate()
    {
        getTime();
    }


    private void getTime(){
        float length;
        float newNum;
        if (musicEventInstances.isValid()){
            length = getSubTime(parameterCount);
            int timelinePosition;
            musicEventInstances.getTimelinePosition(out timelinePosition);
            float currentTime = (float)timelinePosition / 1000.0f;
            //Debug.Log("Current time in sub-event: " + currentTime);
            Debug.Log(length);
            if(currentTime >= length - fadeOut){
                musicEventInstances.setTimelinePosition(0);
                newNum = Random.Range(0f,8f);
                if(parameterCount != newNum){
                    newNum = Random.Range(0f,8f);
                }                    
                SetMusic(newNum);
                length = getSubTime(newNum);
                parameterCount = newNum;
            }
                        
        }

    }
    private void InitializeAmbience(EventReference ambienceEventReference){
        ambienceEventInstances = CreateInstance(ambienceEventReference);
        ambienceEventInstances.start();
    }

    private void plskillme(){
/*        subEventInstances = musicDescription.getInstances();
        foreach (EventInstance subEventInstance in subEventInstances){
            float length = subEventInstance.getTimelineLength();
            Debug.Log("Subevent length: " + length);
        }
*/
    }

    private void InitializeMusic(EventReference musicEventReference){
        musicEventInstances = CreateInstance(musicEventReference);
        musicEventInstances.getDescription(out musicDescription);
    }

    public void SetMusic(float paramNum){
        musicEventInstances.setParameterByName("Menu", paramNum);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos){
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public float getSubTime(float paramNum){
        if((int) paramNum == 0){
            testInstance = RuntimeManager.CreateInstance("{de1f5f7d-56d9-4a1d-80cb-101c7b07b642}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 1){
            testInstance = RuntimeManager.CreateInstance("{0f9377c1-1688-479f-9c3e-0311c3e8f70b}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 2){
            testInstance = RuntimeManager.CreateInstance("{f4cb8da0-6e41-4b94-aa6d-2111c0a7eb11}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 3){
            testInstance = RuntimeManager.CreateInstance("{6741693d-1e36-4ab3-920e-2e59acb7955a}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 4){
            testInstance = RuntimeManager.CreateInstance("{a39974a5-ad3b-46b1-9853-65bfd476978c}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 5){
            testInstance = RuntimeManager.CreateInstance("{72e16d79-5383-4ee2-9b87-843157b209e1}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 6){
            testInstance = RuntimeManager.CreateInstance("{81a07dd8-44f4-4398-a040-3969646e7450}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 7){
            testInstance = RuntimeManager.CreateInstance("{94dccdeb-35c1-4992-a1a1-1448faa95312}}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        else{
            testInstance = RuntimeManager.CreateInstance("{d1dc50e9-c865-4c2c-9550-bc81e2f16707}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
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
