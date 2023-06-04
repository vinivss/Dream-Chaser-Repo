using Coffee;
using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine;

public class TwoDDialogueBottle : MonoBehaviour
{
    

    DialogueManager dialogueManager;
    public bool hasRecipe = false;
    public Recipe WantedRecipe;
    GameManager gameManager;
    public DialogueTree Alternatetree;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void StartDialogue(DialogueTree Tree)
    {
        dialogueManager.dialogue = Tree;
        if(dialogueManager.dialogueStarted == false)
        dialogueManager.DisplayDialogue();

        else
        {
            dialogueManager.dialogue = Alternatetree;
            dialogueManager.DisplayDialogue();
        }

        
    }

    public bool FindRecipe()
    {

        if (hasRecipe == true)
        {
            if (WantedRecipe == gameManager.CurrentCarryingRecipe)
            {
                hasRecipe = true;
            }
            else
            {
                hasRecipe = false;
            }
        }

       return hasRecipe;
    }

}
