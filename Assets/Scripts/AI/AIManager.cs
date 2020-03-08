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

    [SerializeField]List<Transform> _patrolPoints;

    [SerializeField] public Vector3 _target;
    public Rigidbody2D _rb;

    public Path path;
    public float speed = 2;
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;
    Seeker seeker;

    public AISettings _settings;

    private void Start()
    {
        SetupStates();

        _rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
    }

    private void SetupStates()
    {
        
        _stateManager = GetComponent<AIStateManager>();
        _initialStates = new Dictionary<Type, BaseAIState>
        {
            {typeof(UnawareState), new UnawareState(this)},
            {typeof(AwareState), new AwareState(this)},
            {typeof(PatrolState), new PatrolState(this)},
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

    public void SetDestination(Vector2 dest)
    {
            seeker.StartPath(transform.position, dest, OnPathComplete);    
    }

    public Vector2 RandomPosition()
    {
        return (Vector2)new Vector2(UnityEngine.Random.Range(0.0F, 5.0F),
             UnityEngine.Random.Range(0.0F, 5.0F));
    }

    public void Patrol()
    {
        if (_patrolPoints.Count > 0)
        {
            StopAllCoroutines();
            StartCoroutine(PatrolWaypoints());
        }
    }

    IEnumerator PatrolWaypoints()
    {
        int currentWaypoint = 0;
        while (true)
        {
            if(currentWaypoint == _patrolPoints.Count)
            {
                currentWaypoint = 0;
            }

            SetDestination(_patrolPoints[currentWaypoint].position);
            yield return new WaitUntil(() => reachedEndOfPath);
            yield return new WaitForSeconds(2F);

            currentWaypoint++;
        }
    }

    IEnumerator LookForPlayer()
    {
        return null;
    }
}
    

