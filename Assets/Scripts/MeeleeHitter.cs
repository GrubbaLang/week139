using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleeHitter : MonoBehaviour
{
    public LayerMask enemies;
    public Transform originPoint;

    public Vector2 attackBounds;
    public CapsuleDirection2D capsDirection;


    /// <summary>
    /// Use only if you've already set up attack point if not use attack(transform)
    /// </summary>
    public void Attack()
    {
        //remember world space so have to also use transform.rot.euler.z
        //Physics2D.OverlapCapsule();
    }

    public void Attack(Transform origin)
    {
        originPoint = origin;
        Attack();
    }

}
