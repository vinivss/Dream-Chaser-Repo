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
            testInstance = RuntimeManager.CreateInstance("{6741693d-1e36-4ab3-920e-2e59acb7955a}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 3){
            testInstance = RuntimeManager.CreateInstance("{a39974a5-ad3b-46b1-9853-65bfd476978c}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 4){
            testInstance = RuntimeManager.CreateInstance("{d1dc50e9-c865-4c2c-9550-bc81e2f16707}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 5){
            testInstance = RuntimeManager.CreateInstance("{c7fca389-a5fb-43b8-a1f4-4a7f7632c184}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 6){
            testInstance = RuntimeManager.CreateInstance("{883460bb-3abd-4b90-b18b-c54bcdc9cb8e}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 7){
            testInstance = RuntimeManager.CreateInstance("{650ccc8d-5ccb-4d1e-bbcb-6af426de3052}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 8){
            testInstance = RuntimeManager.CreateInstance("{aaad80a4-0b32-410d-89b4-39ec15589ce3}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 9){
            testInstance = RuntimeManager.CreateInstance("{9876f97d-7be0-4591-bb8b-c5f8ee10b49e}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 10){
            testInstance = RuntimeManager.CreateInstance("{fb902680-d481-489a-a696-19b1446a4963}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 11){
            testInstance = RuntimeManager.CreateInstance("{e37803dd-3f56-4788-a187-22abcc3df73a}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 12){
            testInstance = RuntimeManager.CreateInstance("{0e20e481-bcee-42a8-b53f-37fc96ff6073}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 13){
            testInstance = RuntimeManager.CreateInstance("{8bdeda93-610c-409f-9c9f-05a112c0f52b}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 14){
            testInstance = RuntimeManager.CreateInstance("{d8d204d9-3e5c-46ec-b4d9-e97c39a16025}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 15){
            testInstance = RuntimeManager.CreateInstance("{54102c94-426f-40f8-bce4-769690453ace}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 16){
            testInstance = RuntimeManager.CreateInstance("{70c4710d-9578-4640-bf2f-1934b37a72df}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 17){
            testInstance = RuntimeManager.CreateInstance("{234d5c11-4e79-4bc1-8cd0-e1413b82b549}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 18){
            testInstance = RuntimeManager.CreateInstance("{1b9761fc-5eb2-4dbe-9205-40a13dc627b7}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 19){
            testInstance = RuntimeManager.CreateInstance("{8b151ca6-75be-4302-a336-b6a4f0a981d1}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 20){
            testInstance = RuntimeManager.CreateInstance("{c90297fe-269a-4db9-8aa1-6891df003cbc}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if((int) paramNum == 21){
            testInstance = RuntimeManager.CreateInstance("{c90297fe-269a-4db9-8aa1-6891df003cbc}");
            testInstance.getDescription(out eventDescription);
            eventDescription.getLength(out int lengthInMilliseconds);
            float sum = (float) lengthInMilliseconds / 1000.0f;
            return sum;
        }
        if ((int) paramNum == 22){
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
