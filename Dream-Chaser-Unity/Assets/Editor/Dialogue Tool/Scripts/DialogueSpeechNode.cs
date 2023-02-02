using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Trees.Dialogue
{
    public class DialogueSpeechNode : DialogueNode
    {
        [HideInInspector]public DialogueNode child;
        [Space]
        [Header("UI Editors")]
        [Tooltip("Image displayed as character is talking")]
        public Sprite Portrait;
        
        public override void OnStart()
        {
            state = State.CUR;
            child.state = State.NXT;
        }

        public void DisplayDialogue()
        {

        }

        public override void EndNode()
        {
            state = State.FIN;
            child.OnStart();
        }

        public override DialogueNode Clone()
        {
            DialogueSpeechNode node = Instantiate(this);
            node.child = child;
            return node;
        }
    }
}
