using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SubEventTimes : MonoBehaviour
{
    private EventInstance testInstance;
    private EventDescription eventDescription;
    private float subEventLength;

    //get the length of the subEvent
    public float getSubTime(float paramNum){ //Vini I know this function looks like the biggest piece of dog shit I was trying to figure out why shit didnt work and I am WAAY to lazy to make this look organized
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
        if((int) paramNum == 8){
            testInstance = RuntimeManager.CreateInstance("{d1dc50e9-c865-4c2c-9550-bc81e2f16707}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        else{
            testInstance = RuntimeManager.CreateInstance("{c7fca389-a5fb-43b8-a1f4-4a7f7632c184}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
    }
}
