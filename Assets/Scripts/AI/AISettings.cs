using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AISettings 
{
    [Header("Movement")]
    [Range(0.0F, 40F)]
    [SerializeField] public float _movementSpeed = 3F;

    [Header("Chase")]
    [Tooltip("Distance of chasing before ai will stop.")]
    [Range(0.0F, 40F)]
    [SerializeField] public float _chaseDistance = 5F;

    [Header("Patrolling Settings")]
    [SerializeField] public List<Transform> _patrolPoints;



}
