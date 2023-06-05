using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Trees.AI;

public class AIAttack : AIActionNode
{
    private AIAgent boss;
    [SerializeField] private GameObject player;

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
        Debug.Log("calling aiattack");
        Transform player_position = player.transform;
        DCMoveVin p = player.GetComponentInChildren<DCMoveVin>();
        _attackCounter += Time.deltaTime;
        if (_attackCounter >= _attackTime)
        {
            boss.attack();
            _attackCounter = 0f;
        }

        if (!p)
        {
            Debug.Log("null");
        }

        if (p.isAlive)
        {
            return State.RUN;
        }
        else
        {
            return State.SUCC;
        }
    }
}
