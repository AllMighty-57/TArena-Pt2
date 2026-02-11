using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform PatrolRoute;

    public Transform Player;

    public List<Transform> Locations;

    private int _locationIndex = 0;
    
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        Player = GameObject.Find("Player").transform;

        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    private int _lives = 4;
    public int EnemyLives
    {
        // 2 
        get { return _lives; }
        // 3 
        private set
        {
            _lives = value;
            // 4 
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }


    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return; 

        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }


    void OnTriggerStay(Collider other)
    {        
        if (other.name == "Player")
        {
            _agent.destination = Player.position;

            Debug.Log("Player detected - attack!");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            // 6 
            EnemyLives -= 1;
            Debug.Log("Critical hit!");
        }
        else if (collision.gameObject.name == "Slug(Clone)")
        {
            EnemyLives -= 3;
            Debug.Log("Hole in him!");
        }
    }


    void OnTriggerExit(Collider other)
    {        
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resuming patrol");
        }
    }
}
