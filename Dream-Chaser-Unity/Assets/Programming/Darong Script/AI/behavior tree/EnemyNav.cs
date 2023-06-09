using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Tools.Trees.AI;

public class EnemyNav : AIActionNode
{
    private Transform[] checkpoints;
    private NavMeshAgent meshAgent;
    private bool flag;
    //private DCMoveVin player;
    Transform destination;

    protected override void OnStart()
    {
        Debug.Log("nav start");
        checkpoints = agent.checkpointLocation;
        meshAgent = agent.meshAgent;
        //player = agent.player;
        updateDestination();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        Debug.Log(agent.checkpoint.totalCheckpoints + " at on update");
        Debug.Log("current: " + agent.checkpoint.currentCheckpoint() + " at on update");
        float distance = Vector3.Distance(destination.position, agent.transform.position);
        Debug.Log("nav");
        if (agent.checkpoint.currentCheckpoint() < agent.checkpoint.totalCheckpoints)
        {
            //updateDestination();
            
            if (distance > 0.2f)
            {
                updateDestination();
            }
            
            Debug.Log("return run at nav");
            return State.SUCC;

        }
        else
        {

            Debug.Log("return succ at nav");
            
        }

        if (agent.player_health.hp == 0)
        {
            return State.SUCC;
        }
        return State.RUN;
    }

    void updateDestination()
    {

        Debug.Log(agent.checkpoint.totalCheckpoints);
        if (agent.checkpoint.currentCheckpoint() == agent.checkpoint.totalCheckpoints)
        {
            return;
        }
        destination = checkpoints[agent.checkpoint.currentCheckpoint()];

        meshAgent.isStopped = false;
        /*
        if (meshAgent.velocity != player.getCurrentVelocity())
        {
            meshAgent.velocity = player.getCurrentVelocity();
        }
        */
        agent.checkpoint.arriveCheckpoint();
        meshAgent.SetDestination(destination.position);
    }


}
