using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class HumanWalkScript : MonoBehaviour
{
    public GameObject[] pointOfInterest;
    public NavMeshAgent agent;

    public GameObject currentLocationToMove;

    private void Start()
    {
        Move();
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, currentLocationToMove.transform.position) <= 1)
        {
            Move();
        }
    }

    private void Move()
    {
        int range = Random.Range(1, 5);
        currentLocationToMove = pointOfInterest[range];
        agent.SetDestination(currentLocationToMove.transform.position);
    }
}