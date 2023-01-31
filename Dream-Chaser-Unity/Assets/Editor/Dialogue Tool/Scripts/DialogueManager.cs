using UnityEngine;
using Tools.Trees.Dialogue;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Tooltip("This is the dialogue that will be referenced for dialogue")]
    [SerializeField] DialogueTree dialogue;
    DialogueNode currentNode;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    int ChoiceIndex;
    bool dialogueStarted = false;
    // Start is called before the first frame update
    void Start()
    {
       currentNode = dialogue.RootNode;

        DisplayDialogue();
    }

    private void DisplayDialogue()
    {
        if(dialogueStarted == false)
        {
            dialogueStarted = true;
            //create window for dialogue 
        }


    }

    void ChangeNode()
    {
        if(currentNode.state == DialogueNode.State.FIN)
        {
              List<DialogueNode> Children =  dialogue.GetChildren(currentNode);

            if(Children.Count == 1)
            {
                currentNode = Children[0];
            }
            else if(Children.Count > 1)
            {
                InstantiateChoices(Children);
                
            }
            else
            {
                CloseDialogue();
            }
            
        }
    }

    //creating and displaying UI settings.
    private void InstantiateChoices(List<DialogueNode> children)
    {
        // foreach child create a different button prefab with the text choice.

        //give each button an index which is called on Selected option that matches the option
    }

    //event that will be called upon the clicking of a button
    void SelectedOption(int index)
    {
        //get index from button
        List<DialogueNode> Children =  dialogue.GetChildren(currentNode);
        currentNode = Children[index];
        currentNode.EndNode();
    }
    //get the input
    private void CloseDialogue()
    {
        throw new NotImplementedException();
    }
}
