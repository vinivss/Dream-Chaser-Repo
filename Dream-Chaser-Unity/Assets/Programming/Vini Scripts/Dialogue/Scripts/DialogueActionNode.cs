using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine;

public abstract class DialogueActionNode : DialogueNode
{
    public bool finished = false;
    public override void EndNode()
    {
        finished = true;
    }

    public override void OnStart()
    {
        this.started = true;
        Action();
    }
    public abstract void Action(); 
}
