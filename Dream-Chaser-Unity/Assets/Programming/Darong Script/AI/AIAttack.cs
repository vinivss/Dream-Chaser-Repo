using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class AIAttack : AIActionNode
{
    private EnemyAI boss;
    private GameObject player;

    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    protected override void OnStart()
    {

    }
    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        Transform player_position = player.transform;

        _attackCounter += Time.deltaTime;
        if (_attackCounter >= _attackTime)
        {
            boss.attack();
            _attackCounter = 0f;
        }


        return State.RUN;
    }
}
