using Coffee;
using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoDDialogueBottle : MonoBehaviour
{
    

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
        
    }

    public void StartDialogue(DialogueTree Tree)
    {

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
