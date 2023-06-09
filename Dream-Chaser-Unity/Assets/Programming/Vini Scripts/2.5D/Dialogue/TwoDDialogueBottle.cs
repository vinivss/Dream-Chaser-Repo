using Coffee;
using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class TwoDDialogueBottle : MonoBehaviour
{
    //Jingles
    [field: Header("Jingle")]
    [field: SerializeField] public EventReference jingle {get; private set; }
    EventInstance jingleInstance;
    VNAudioManager audioM;

    DialogueManager dialogueManager;
    public bool hasRecipe = false;
    bool Alternate = false;
    public Recipe WantedRecipe;
    GameManager gameManager;
    public GameObject LoadingScreen;
    [Header("Guests Things")]
    public DialogueTree Alternatetree;
    public DialogueTree CorrectGuessTree;

    [Header("Main VN scenes")]
    public string CorrectScene;
    public string IncorrectScene;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        gameManager = FindObjectOfType<GameManager>();
        audioM = FindObjectOfType<VNAudioManager>();
        jingleInstance = RuntimeManager.CreateInstance(jingle);
    }

    public void StartDialogue(DialogueTree Tree)
    {
        jingleInstance.start();
        audioM.fadeOut();
        if (Alternate == false)
        {
            Alternate = true;
            dialogueManager.dialogue = Tree;
            dialogueManager.DisplayDialogue();
        }

        else if (Alternate == true)
        {
           if (dialogueManager.Unlocked == false || hasRecipe == false)
           {
                dialogueManager.dialogue = Alternatetree;
                dialogueManager.DisplayDialogue();
           }

           else if(dialogueManager.Unlocked == true)
            {
                dialogueManager.dialogue = CorrectGuessTree;
                dialogueManager.DisplayDialogue();
            }
           
        }

        
    }
    public void VNScenePlay()
    {
        if(dialogueManager.Unlocked == true || FindRecipe())
        {
            StartCoroutine(LoadSceneAsync(CorrectScene));
        }
        else
        {
            StartCoroutine(LoadSceneAsync(IncorrectScene));
        }
    }
    IEnumerator LoadSceneAsync(string sceneName)
    {
        audioM.thanos();
        LoadingScreen = Instantiate(LoadingScreen, GameObject.FindObjectOfType<Canvas>().transform);
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        while (!op.isDone)
        {
            yield return null;
        }
    }

    public bool FindRecipe()
    {

        if (hasRecipe == true)
        {
            if (WantedRecipe == gameManager.CurrentCarryingRecipe)
            {
               gameManager.CurrentCarryingRecipe = null;
               return true;
            }
        }

        
       return false;
    }

}
