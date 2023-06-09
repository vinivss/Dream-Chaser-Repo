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
            testInstance = RuntimeManager.CreateInstance("{0168c8f1-b966-4bd2-aac1-40051e78e5e5}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 1){
            testInstance = RuntimeManager.CreateInstance("{b0a68eb6-ad26-43ea-a910-6309119dc302}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 2){
            testInstance = RuntimeManager.CreateInstance("{b1bb213b-b642-4c08-9734-a71ea3f08fa8}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 3){
            testInstance = RuntimeManager.CreateInstance("{ec2dc513-9cbb-4f78-9626-9b90b23b0a55}");
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
