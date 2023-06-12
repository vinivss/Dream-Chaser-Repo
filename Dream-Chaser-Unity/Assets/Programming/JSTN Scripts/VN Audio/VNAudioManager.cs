using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;

public class VNAudioManager : MonoBehaviour
{
//    static AudioManager AMInstance;
    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    public EventInstance musicEventInstances;
    public EventInstance sfxEventInstances;
    DialogueManager dManager;
    KillAudioManagers kill;
    public static VNAudioManager instance { get; private set;}

    private void Awake(){
        // if(instance == null)
        // {
            //For NextButton clicks
            dManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
            kill = FindObjectOfType<KillAudioManagers>();
            instance = this;
            DontDestroyOnLoad(instance);
            if (instance != null){
                //Debug.LogError("Found more than one Audio Manager in scene");
            }
        // }
        // else
        // {
        //     DestroyImmediate(gameObject);
        // }        
    }

    private void Start(){
        InitializeMusic(VNEvents.instance.music);
        InitializeSFX(VNEvents.instance.sfx);
        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate()
    {
        //Play sound upon clicking next
        //dManager.NextButton.GetComponent<Button>().onClick.AddListener(ClickNextButton);
        
    }

    public void ClickNextButton()
    {
        sfxEventInstances.start();
    }

    private void InitializeSFX(EventReference sfxEventReference){
        sfxEventInstances = CreateInstance(sfxEventReference);
    }

    private void InitializeMusic(EventReference musicEventReference){
        musicEventInstances = CreateInstance(musicEventReference);
        musicEventInstances.start();
    }

    public IEnumerator fadeOut()
    {
        musicEventInstances.setParameterByName("pause", 1);
        yield return new WaitForSeconds(5.5f);
        musicEventInstances.setParameterByName("pause", 0);
    }

    public void thanos(){
        musicEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        sfxEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Destroy(gameObject);
    }

    public EventInstance CreateInstance(EventReference eventReference){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
