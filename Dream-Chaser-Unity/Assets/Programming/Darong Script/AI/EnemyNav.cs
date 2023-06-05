using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Tools.Trees.AI;

public class EnemyNav : AIActionNode
{
    private Transform[] checkpoints;
    private AIAgent enemy;
    private NavMeshAgent meshAgent;
    private DCMoveVin player;
    Transform destination;
    
    public EnemyNav(Transform[] checkpoints, AIAgent enemy, NavMeshAgent meshAgent, DCMoveVin player)
    {
        this.checkpoints = checkpoints;
        this.enemy = enemy;
        this.meshAgent = meshAgent;
        this.player = player;
    }

    protected override void OnStart()
    {
        Debug.Log("nav start");
        updateDestination();
    }
    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        float distance = Vector3.Distance(destination.position, agent.transform.position);
        Debug.Log("nav");
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
        if (checkpoints == null)
        {
            Debug.Log("no checkpoint");
        }
        Debug.Log(checkpoints.Length);
        if (enemy == null)
        {
            Debug.Log("no enemy");
        }
        if (enemy.checkpoint == null)
        {
            Debug.Log("no enemy checkpoint");
        }
        Debug.Log(enemy.checkpoint.currentCheckpoint());
        destination = checkpoints[enemy.checkpoint.currentCheckpoint()];

        meshAgent.isStopped = false;
        /*
        if (meshAgent.velocity != player.getCurrentVelocity())
        {
            meshAgent.velocity = player.getCurrentVelocity();
        }
        */
        enemy.checkpoint.arriveCheckpoint();
        meshAgent.SetDestination(destination.position);
    }


}
