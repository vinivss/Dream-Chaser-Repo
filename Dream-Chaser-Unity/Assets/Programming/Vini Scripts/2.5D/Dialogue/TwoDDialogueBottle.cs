using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine;

public class TwoDDialogueBottle : MonoBehaviour
{
    

    DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void StartDialogue(DialogueTree Tree)
    {
        dialogueManager.dialogue = Tree;
        if(dialogueManager.dialogueStarted == false)
        dialogueManager.DisplayDialogue();
    }
}
