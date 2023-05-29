using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class SelectorNode : AICompositeNode
{
    int curr;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        var child = children[curr];
        switch (child.Update())
        {
            case State.RUN:
                return State.RUN;
            case State.FAIL:
                curr++;
                break;
            case State.SUCC :
                return State.SUCC;    
        }

        return curr == children.Count ? State.FAIL : State.RUN;
    }
}
