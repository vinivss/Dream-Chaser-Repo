using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Trees.Dialogue
{
    public class DialogueOptionNode : DialogueNode
    {
        [HideInInspector]public DialogueNode child;
        [HideInInspector] public List<DialogueNode> DialogueActions;
        


        public override void OnStart()
        {
            state = State.CUR;
            child.state = State.NXT;
        }

        public void DisplayDialogue ()
        {

        }
        public override void EndNode()
        {
            state = State.FIN;
            child.OnStart();
        }

        public override DialogueNode Clone()
        {
            DialogueOptionNode node = Instantiate(this);
            node.child = child;
            return node;
        }
    }
}
