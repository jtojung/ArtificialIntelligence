using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Patrol = 0,
        Seek = 1
    }

    public NavMeshAgent agent;
    public State currentState = State.Patrol;
    public Transform target;
    public float seekRadius = 5f;

    public Transform waypointParent;
    public float stoppingDistance = 1f;

    // Creates a collection of Transforms
    private Transform[] waypoints;
    private int currentIndex = 1;

    // CTRL + M + O (Fold Code)
    // CTRL + M + P (UnFold Code)
   
    void Patrol()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < stoppingDistance)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);
        agent.SetDestination(point.position);

        float distToTarget = Vector3.Distance(transform.position, target.position); 
        if(distToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    void Seek()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
        agent.SetDestination(target.position);
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget > seekRadius)
        {
            currentState = State.Patrol;
        }
    }
    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                break;
        }
    }
}
