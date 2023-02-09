using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Trees.Dialogue
{
    public class DialogueSpeechNode : DialogueNode
    {
        [HideInInspector]public DialogueNode child;        
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
