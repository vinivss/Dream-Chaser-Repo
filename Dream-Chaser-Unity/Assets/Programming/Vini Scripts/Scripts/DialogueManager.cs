using UnityEngine;
using Tools.Trees.Dialogue;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Tooltip("This is the dialogue that will be referenced for dialogue")]
    [SerializeField] DialogueTree dialogue;
    DialogueNode currentNode;
    [Header("Dialogue Box Attributes")]
    [Tooltip("Name Of Speaker")]
    public TextMeshProUGUI nameText;
    [Tooltip("Name Of Speaker")]
    public TextMeshProUGUI dialogueText;
    int ChoiceIndex;
    bool dialogueStarted = false;
    public GameObject DialogueBox;
    public Transform DialogueBoxTransform;
    Button NextButton;
    GameObject DialogueSprite;
    GameObject runTimeWindow;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogue != null)
        {
            currentNode = dialogue.RootNode;

            DisplayDialogue();
        }
    }

    private void DisplayDialogue()
    {
        if(dialogueStarted == false)
        {
            dialogueStarted = true;
            //create window for dialogue 
            runTimeWindow = Instantiate(DialogueBox,DialogueBoxTransform);
        }
        nameText = GameObject.Find("Speaker").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
        NextButton = GameObject.Find("NextButton").GetComponent<Button>();

        NextButton.GetComponent<Button>().onClick.AddListener(ChangeNode);
        DialogueSprite = GameObject.Find("Speaking Sprite");
        currentNode.state = DialogueNode.State.FIN;
        ChangeNode();
    }

    public void ChangeNode()
    {
        if(currentNode.state == DialogueNode.State.FIN)
        {
            List<DialogueNode> Children =  dialogue.GetChildren(currentNode);

            if(Children.Count == 1)
            {
                currentNode = Children[0];
                if(currentNode is DialogueEndNode)
                {
                    CloseDialogue();
                }
                DialogueSprite.GetComponent<Image>().sprite = currentNode.Portrait;
                DisplayNextSentence();  
                currentNode.state = DialogueNode.State.FIN; 
            }
            else if(Children.Count > 1)
            {
                InstantiateChoices(Children);
            } 
        }
    }

    void DisplayNextSentence()
    {
        nameText.text = currentNode.Speaker;
        StopAllCoroutines();
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
      
        dialogueText.text = "";

        foreach(char letter in currentNode.Dialogue.ToCharArray())
        {
            dialogueText.text += letter;

            yield return null;
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
        DestroyImmediate(runTimeWindow);
    }
}
