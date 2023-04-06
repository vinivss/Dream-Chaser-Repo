using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SubEventTimes : MonoBehaviour
{
    private EventInstance eventInstance;
    private EventDescription eventDescription;
    private float subEventLength;

    public float getSubTime(float paramNum){
        if(paramNum == 0){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{de1f5f7d-56d9-4a1d-80cb-101c7b07b642}");
            eventInstance.getDescription(out eventDescription);
        }
        if(paramNum == 1){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{0f9377c1-1688-479f-9c3e-0311c3e8f70b}");
            eventInstance.getDescription(out eventDescription);
        }
        if(paramNum == 2){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{f4cb8da0-6e41-4b94-aa6d-2111c0a7eb11}");
            eventInstance.getDescription(out eventDescription);
        }
        if(paramNum == 3){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{6741693d-1e36-4ab3-920e-2e59acb7955a}");
            eventInstance.getDescription(out eventDescription);
        }
        if(paramNum == 4){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{a39974a5-ad3b-46b1-9853-65bfd476978c}");
            eventInstance.getDescription(out eventDescription);
        }
        if(paramNum == 5){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{72e16d79-5383-4ee2-9b87-843157b209e1}");
            eventInstance.getDescription(out eventDescription);
        }
        if(paramNum == 6){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{81a07dd8-44f4-4398-a040-3969646e7450}");
            eventInstance.getDescription(out eventDescription);
        }
        if(paramNum == 7){
            EventInstance eventInstance = RuntimeManager.CreateInstance("{94dccdeb-35c1-4992-a1a1-1448faa95312}}");
            eventInstance.getDescription(out eventDescription);
        }
        else{
            EventInstance eventInstance = RuntimeManager.CreateInstance("{d1dc50e9-c865-4c2c-9550-bc81e2f16707}");
            eventInstance.getDescription(out eventDescription);
        }
        eventDescription.getLength(out int lengthInMilliseconds);
        subEventLength = lengthInMilliseconds / 1000.0f;
        return subEventLength;
    }
}
