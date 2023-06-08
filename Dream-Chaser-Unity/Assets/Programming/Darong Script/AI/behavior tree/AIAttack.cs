using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class AIAttack : AIActionNode
{

    private DCMoveVin player;
    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    protected override void OnStart()
    {
        player = agent.player;
    }
    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {

        agent.attack();
        _attackCounter = 0f;

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
