using Coffee;
using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine;

public class StorySceneDialogueRun : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
