using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class checkNav : SequencerNode
{
    private int index = 0;

    // Update is called once per frame
    protected override State OnUpdate()
    {
        Debug.Log("check alive");
        AINode node = children[index];
        while (node.Update() == State.RUN )
        {
            /*
            Debug.Log("current index in node: " + index);
            if (index == 0)
            {
                Debug.Log("change from 0 to 1");
                index += 1;
            }
            else if(index == 1)
            {
                Debug.Log("change from 1 to 0");
                index = 0;
            }
            */
            node = children[index];
        }
        return State.SUCC;

    }
}
