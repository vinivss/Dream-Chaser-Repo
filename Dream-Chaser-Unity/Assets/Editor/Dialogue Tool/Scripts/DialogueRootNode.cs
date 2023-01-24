using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Trees.Dialogue
{
    public class DialogueRootNode : DialogueNode
    {
        [HideInInspector] public DialogueNode child;


        public override void OnStart()
        {

            EndNode();  
        }

        public override void EndNode()
        {
            state = State.FIN;
            child.OnStart();
        }

        public override DialogueNode Clone()
        {
            DialogueRootNode node = Instantiate(this);
            node.child = child;
            return node;
        }
    }
}
