using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnawareState : BaseAIState
{
    public override AIManager _ai { get; set; }


    public UnawareState(AIManager ai) : base(ai)
    {
        _ai = ai;
    }

    public override void OnStateEnter()
    {
        // _ai.TraverseToRandomPosition();
        _ai.Patrol();
    }
    public override Type Tick()
    {
       if(Vector2.Distance(_ai.transform.position, _ai._Player.transform.position) < 1F)
        {
            return null;
        }
        else
        {
            
            return null;
        }
    }

  
}
