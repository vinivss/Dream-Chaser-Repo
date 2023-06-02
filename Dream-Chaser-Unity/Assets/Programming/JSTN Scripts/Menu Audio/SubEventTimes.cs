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
            testInstance = RuntimeManager.CreateInstance("{c7fca389-a5fb-43b8-a1f4-4a7f7632c184}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 2){
            testInstance = RuntimeManager.CreateInstance("{9876f97d-7be0-4591-bb8b-c5f8ee10b49e}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 3){
            testInstance = RuntimeManager.CreateInstance("{fb902680-d481-489a-a696-19b1446a4963}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 4){
            testInstance = RuntimeManager.CreateInstance("{e37803dd-3f56-4788-a187-22abcc3df73a}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 5){
            testInstance = RuntimeManager.CreateInstance("{70c4710d-9578-4640-bf2f-1934b37a72df}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 6){
            testInstance = RuntimeManager.CreateInstance("{234d5c11-4e79-4bc1-8cd0-e1413b82b549}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 7){
            testInstance = RuntimeManager.CreateInstance("{c90297fe-269a-4db9-8aa1-6891df003cbc}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if ((int) paramNum == 8){
            testInstance = RuntimeManager.CreateInstance("{b7b4dcae-fae5-4613-a0c2-a1d6cbad5cd5}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }if ((int) paramNum == 9){
            testInstance = RuntimeManager.CreateInstance("{8fff49a7-8d75-4da9-a79c-9cd1a10e23d0}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }else{
            Debug.Log("No track loaded :(");
            return 0;
        }
    }
}
