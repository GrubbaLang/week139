using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleeHitter : MonoBehaviour
{
    public LayerMask enemies;
    public Transform originPoint;

    public Vector2 attackBounds;
    /// <summary>
    /// Use only if you've already set up attack point if not use attack(transform)
    /// </summary>
    public void Attack()
    {
        //remember world space so have to also use transform.rot.euler.z
        var result = Physics2D.OverlapBoxAll((Vector2)originPoint.position, attackBounds, transform.rotation.eulerAngles.z, enemies);
        if(result.Length > 0)
        {

        }
    }

    public void Attack(Transform origin)
    {
        originPoint = origin;
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(originPoint.position, attackBounds);
    }
}