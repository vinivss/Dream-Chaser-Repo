using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TriggerAudio : MonoBehaviour
{
    public string path;
    public bool PlayOnAwake;
    public bool PlayOnDestroy;

    public void PlayWind(string path){
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
    /*private void Start(){
        if(PlayOnAwake)
            PlayOneShot();
    }
    private void OnDestroy(){
        if(PlayOnDestroy)
            PlayOneShot();
    }*/
}
