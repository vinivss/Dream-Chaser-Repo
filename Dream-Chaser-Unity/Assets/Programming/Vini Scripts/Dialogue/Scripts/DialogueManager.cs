using UnityEngine;
using Tools.Trees.Dialogue;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Tooltip("This is the dialogue that will be referenced for dialogue")]
    public DialogueTree dialogue;
    DialogueNode currentNode;
    [Header("Dialogue Box Attributes")]
    [Tooltip("Name Of Speaker")]
    public TextMeshProUGUI nameText;
    [Tooltip("Dialogue Text")]
    public TextMeshProUGUI dialogueText;
    int ChoiceIndex;
    bool dialogueStarted = false;
    [Header("Prefabs")]
    [Tooltip("Prefab to be instantiated as dialogue box")]
    public GameObject DialogueBox;
    [Tooltip("Where The Dialogue box will be anchored")]
    public Transform DialogueBoxTransform;
    [Tooltip("Prefab to be instantiated as buttons")]
    public GameObject ButtonPrefab;
    [Tooltip("Vertical transform")]
    public Transform LayoutTrans;
    [Tooltip("what will happen at the end of the dialogue")]
    public UnityEvent EndEvent;
    Button NextButton;  
    GameObject runTimeWindow;
    ControlsManager controlVN;
    // Start is called before the first frame update
    void Start()
    {
        controlVN = FindObjectOfType<ControlsManager>().GetComponent<ControlsManager>();
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

        currentNode.state = DialogueNode.State.FIN;
        ChangeNode();
    }

    public void ChangeNode()
    {
        if (currentNode.state == DialogueNode.State.FIN)
        {
            if (currentNode.SceneLayout != null)
                DestroyImmediate(currentNode.SceneLayout);

            List<DialogueNode> Children = dialogue.GetChildren(currentNode);

            if (Children.Count == 1)
            {
                currentNode = Children[0];
                if (currentNode is DialogueEndNode)
                {
                    CloseDialogue();
                }

                DisplayNextSentence();
                if(currentNode.SceneLayout != null)
                    currentNode.SceneLayout = Instantiate(currentNode.SceneLayout);

                currentNode.state = DialogueNode.State.FIN;
            }
            else if (Children.Count > 1)
            {
                InstantiateChoices(Children);
                if (currentNode.SceneLayout != null)
                    currentNode.SceneLayout = Instantiate(currentNode.SceneLayout);
            }
        }
    }
    void Skip()
    {
            StopCoroutine(TypeSentence());
            dialogueText.text = "";
            dialogueText.text = currentNode.Dialogue; 
    }

    void DisplayNextSentence()
    {
        nameText.text = currentNode.Speaker;
        Skip();
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence());

    }

    IEnumerator TypeSentence()
    {
      
        dialogueText.text = "";

        foreach(char letter in currentNode.Dialogue.ToCharArray())
        {

            if (controlVN.GetAcceptValue())
            {
                Skip();
                break;
            }

            dialogueText.text += letter;

            yield return null;
        }
    }
    //creating and displaying UI settings.
    private void InstantiateChoices(List<DialogueNode> children)
    {
        runTimeWindow.SetActive(false);
      
        int i = 0;
        // foreach child create a different button prefab with the text choice.
        //give each button an index which is called on Selected option that matches the option
        foreach (DialogueOptionNode Node in children)
        {
            int x = i;
            Button OptionButton = Instantiate(ButtonPrefab, LayoutTrans).GetComponent<Button>();
            Debug.Log(i);
            OptionButton.GetComponent<Button>().onClick.AddListener(delegate {SelectedOption(x);});
            OptionButton.GetComponentInChildren<TextMeshProUGUI>().text = Node.Dialogue;
            i++;
        }
    }



    //event that will be called upon the clicking of a button
    public void SelectedOption(int index)
    {
        Debug.Log(index);
        //get index from button
        List<DialogueNode> Children =  dialogue.GetChildren(currentNode);
        Debug.Log(Children.Count);
        currentNode = Children[index];
        currentNode.EndNode();
        runTimeWindow.SetActive(false);
        DeleteAllButtons();
        runTimeWindow.SetActive(true);
        ChangeNode();
    }

    private void DeleteAllButtons()
    {
        GameObject[] Buttons = GameObject.FindGameObjectsWithTag("DialogueButts");
        foreach (GameObject Button in Buttons)
        {
            DestroyImmediate(Button);
        }
    }

    //get the input
    private void CloseDialogue()
    {
        EndEvent.Invoke();
    }
}
