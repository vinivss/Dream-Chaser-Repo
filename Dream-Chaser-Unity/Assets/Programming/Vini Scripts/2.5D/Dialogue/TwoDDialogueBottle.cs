using Coffee;
using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine;

public class TwoDDialogueBottle : MonoBehaviour
{
    

    DialogueManager dialogueManager;
    public bool hasRecipe = false;
    bool Alternate = false;
    public Recipe WantedRecipe;
    GameManager gameManager;
    public DialogueTree Alternatetree;
    public DialogueTree CorrectGuessTree;
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
