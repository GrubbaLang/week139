using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeeleeHitter))]
public class MeeleeUsable : DefaultUsable
{

    public float activeTime = 0.2f;

    MeeleeHitter hitter;

    private void Start()
    {
        hitter = GetComponent<MeeleeHitter>();
    }

    public override void onThrow(Transform args1)
    {
        base.onThrow(args1);
        var pickable = pickableGO.GetComponent<MeeleePickable>();
        hitter.originPoint.position -= (Vector3)pickable.weaponPointOffset;
        hitter.originPoint = null;
        
    }
}
