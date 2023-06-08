using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAINode : Node
{
    private EnemyAI ai;
    private float threshhold;

    public HealthAINode(EnemyAI ai, float threshhold)
    {
        this.ai = ai;
        this.threshhold = threshhold;
    }

    public override NodeState Evaluate()
    {
        return ai.GetCurrentHealth() <= threshhold ? NodeState.SUCCESS : NodeState.FAILLURE;
    }
}
