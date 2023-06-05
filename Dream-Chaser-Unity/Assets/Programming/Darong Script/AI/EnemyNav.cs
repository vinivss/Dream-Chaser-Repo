using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Tools.Trees.AI;

public class EnemyNav : AIActionNode
{
    private Transform[] checkpoints;
    private EnemyAI enemy;
    private NavMeshAgent meshAgent;
    private DCMoveVin player;
    Transform destination;
    
    public EnemyNav(Transform[] checkpoints, EnemyAI enemy, NavMeshAgent meshAgent, DCMoveVin player)
    {
        this.checkpoints = checkpoints;
        this.enemy = enemy;
        this.meshAgent = meshAgent;
        this.player = player;
    }

    protected override void OnStart()
    {

    }
    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        float distance = Vector3.Distance(destination.position, agent.transform.position);

        if (distance > 0.2f)
        {
            updateDestination();
        }


        if (enemy.checkpoint.currentCheckpoint() <= enemy.checkpoint.totalCheckpoints)
        {
            return State.RUN;
        }
        else 
        {
            return State.SUCC;
        }
    }

    void updateDestination()
    {
        destination = checkpoints[enemy.checkpoint.currentCheckpoint()];
        meshAgent.isStopped = false;
        meshAgent.velocity = player.getCurrentVelocity();
        enemy.checkpoint.arriveCheckpoint();
        meshAgent.SetDestination(destination.position);
    }


}
