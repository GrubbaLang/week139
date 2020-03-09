using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MeeleeHitter : MonoBehaviour
{
    public int damage;
    public LayerMask enemies;
    public Transform originPoint;
    public GameObjectGameEvent onAnyEnemyHit;
    public Vector2 attackBounds;

    public event Action<GameObject, Mortal> onThisHit;
    /// <summary>
    /// Use only if you've already set up attack point if not use attack(transform)
    /// </summary>
    public void Attack()
    {

        //remember world space so have to also use transform.rot.euler.z
        var result = Physics2D.OverlapBoxAll((Vector2)originPoint.position, attackBounds, transform.rotation.eulerAngles.z, enemies);
        if(result.Length > 0)
        {
            foreach (Collider2D n in result)
            {
                var health = n.GetComponent<Mortal>();
                if (health != null)
                {

                    health.Damage(damage);
                    onThisHit(this.gameObject, health);
                    onAnyEnemyHit.Raise(n.gameObject); 
                }

            }
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