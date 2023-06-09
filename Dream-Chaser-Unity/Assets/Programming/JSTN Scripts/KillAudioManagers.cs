using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAudioManagers : MonoBehaviour
{
    MenuAudioManager mmManager;
    VNAudioManager vManager;
    AudioManager gManager;
    
    // Start is called before the first frame update
    public void Start()
    {
        mmManager = FindObjectOfType<MenuAudioManager>().GetComponent<MenuAudioManager>();
        vManager = FindObjectOfType<VNAudioManager>().GetComponent<VNAudioManager>();
        gManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();

        mmManager.thanos();
        vManager.thanos();
        gManager.thanos();
    }
}
