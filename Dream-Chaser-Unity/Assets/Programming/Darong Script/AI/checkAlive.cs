using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class checkAlive : SequencerNode
{
    [SerializeField] private DCMoveVin player;

    // Update is called once per frame
    protected override State OnUpdate()
    {
        if (player.isAlive)
        {
            return State.FAIL;
        }
        else
        {
            return State.SUCC;
        }
    }
}
