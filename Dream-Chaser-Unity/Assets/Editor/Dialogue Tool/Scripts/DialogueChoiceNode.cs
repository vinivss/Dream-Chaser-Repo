using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Trees.Dialogue
{
    public class DialogueChoiceNode : DialogueNode
    {
       [HideInInspector] public List<DialogueNode> children;
       


        public override void OnStart()
        {
            this.state = State.CUR;
            
            foreach (DialogueNode node in children)
            {
                node.state = State.NXT;
            }
        }
        public void DisplayDialogue()
        {

        }
        public override void EndNode()
        {
            throw new System.NotImplementedException();
        }

        public override DialogueNode Clone()
        {
            DialogueChoiceNode node = Instantiate(this);
            node.children = children.ConvertAll(c => c.Clone());
            return node;
        }
    }
}
