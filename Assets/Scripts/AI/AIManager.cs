using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.AI;
using Pathfinding;

public class AIManager : MonoBehaviour
{
    private Dictionary<Type, BaseAIState> _initialStates;
    public GameObject _Player;
    private AIStateManager _stateManager;

    [SerializeField] public Vector3 _target;
    public Rigidbody2D _rb;
    AIDestinationSetter _setter;
    AIPath _agent;
    AILerp lerp;

    public Path path;
    public float speed = 2;
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;
    bool traversing;
    Seeker seeker;




    public AISettings _settings;

   
    private void Start()
    {
        SetupStates();

        _rb = GetComponent<Rigidbody2D>();
        _setter = GetComponent<AIDestinationSetter>();
        _agent = GetComponent<AIPath>();
        seeker = GetComponent<Seeker>();
        lerp = GetComponent<AILerp>();


    }

    private void SetupStates()
    {
        
        _stateManager = GetComponent<AIStateManager>();
        _initialStates = new Dictionary<Type, BaseAIState>
        {
            {typeof(WanderState), new WanderState(this)}
        };
        _stateManager.SetStates(_initialStates);
        
    }


    void Update()
    {
        if (path == null)
        {
            return;
        }
        float distanceToWaypoint;
        reachedEndOfPath = false;
        while (true)
        {
          
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    reachedEndOfPath = true;
                    break;
                }
            }
            else
            {
                break;
            }

   
            var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

            Vector3 velocity = dir * speed * speedFactor;
            transform.position += velocity * Time.deltaTime;
        }
     
    }

    public void ChasePlayer()
    {
        this._target = _Player.transform.position;
    }

    public void TraverseToRandomPosition()
    {
        if (path == null)
        {
            

    
            seeker.StartPath((Vector2)transform.position, new Vector2(UnityEngine.Random.Range(0.0F, 5.0F),
                 UnityEngine.Random.Range(0.0F, 5.0F)), OnPathComplete);
           
        }
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        if (!p.error)
        {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }
}
    

