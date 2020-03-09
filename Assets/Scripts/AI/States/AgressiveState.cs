using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveState : BaseAIState
{
    public override AIManager _ai { get; set; }

    private Transform target;


    public AgressiveState(AIManager ai) : base(ai)
    {
        _ai = ai;
    }

    public override void OnStateEnter()
    {
        target = _ai.GetComponent<AIScanner>()._visibleTargets[0];
        _ai.ChaseTarget(target);
    }

    public override Type Tick()
    {
        if (Vector2.Distance(_ai.transform.position, target.position) > 5)
        {
            return typeof(UnawareState);
        }
        else
        {
            return null;
        }
    }
}
