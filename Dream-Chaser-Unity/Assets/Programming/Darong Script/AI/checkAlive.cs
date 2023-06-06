using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class checkAlive : SequencerNode
{
    [SerializeField] private DCMoveVin player;
    private int index = 0;

    // Update is called once per frame
    protected override State OnUpdate()
    {
        Debug.Log("check alive");
        Debug.Log(player.isAlive);
        AINode node = children[index];
        while (node.Update() == State.RUN)
        {
            if (index == 0)
            {
                index = 1;
            }
            else
            {
                index = 0;
            }
            node = children[index];
        }
        return State.SUCC;
        //Debug.Log(children[1].Update());
        /*
        if (!player.isAlive && children[1].Update() != State.RUN)
        {
            Debug.Log("return run");
            return State.SUCC;
        }
        else
        {
            return State.RUN;
        }
        */

    }
}
