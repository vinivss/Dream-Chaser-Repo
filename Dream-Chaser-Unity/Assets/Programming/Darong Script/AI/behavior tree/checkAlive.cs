using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class checkAlive : SequencerNode
{
    private int index = 0;

    // Update is called once per frame
    protected override State OnUpdate()
    {
        AINode node = children[index];
        while (node.Update() == State.RUN )
        {
            if (index == 0)
            {
                index += 1;
            }
            else if(index == 1)
            {
                index = 0;
            }
            node = children[index];
        }
        return State.SUCC;

    }
}
