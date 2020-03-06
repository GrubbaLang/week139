using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    private Dictionary<Type, BaseAIState> _initialStates;
    private AIStateManager _stateManager;
    [SerializeField] private Transform _target;
    public Rigidbody2D _rb;
    public NavMeshAgent _agent;
    public int _team;

    
    public Transform target { get { return _target; } set{ target = value; }}

    [SerializeField] public AISettings _settings;

    private void OnEnable()
    {
        SetupStates();
    }

    private void Start()
    {
        SetupStates();

        _rb = GetComponent<Rigidbody2D>();
        _agent =  GetComponent<NavMeshAgent>();
    }

    private void SetupStates()
    {
        _stateManager = GetComponent<AIStateManager>();
        _initialStates = new Dictionary<Type, BaseAIState>
        {
       
        };
        _stateManager.SetStates(_initialStates);
    }

    private void Update()
    {
   
    }

}

