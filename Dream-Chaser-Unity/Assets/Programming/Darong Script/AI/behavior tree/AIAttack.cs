using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class AIAttack : AIActionNode
{

    private DCMoveVin player;

    protected override void OnStart()
    {
        
    }
    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        player = agent.player;
        agent.attack();

        if (agent.player_health.healthCheck())
        {
            Debug.Log("keep running attack");
            return State.RUN;
        }
        else
        {
            Debug.Log("attack succ");
            return State.SUCC;
        }
    }
}
