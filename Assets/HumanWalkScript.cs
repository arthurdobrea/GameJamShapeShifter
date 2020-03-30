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
       findNewPlaceToGo();
       moveToPlace();
    }

    void FixedUpdate()
    {
        if (FovDetection.inFOV(transform, ShapeShifterScript.player.transform, 75, 3))
        {
            moveToPlayer();
        }
        else
        {
            moveToPlace();
        }

        if (Vector3.Distance(transform.position, currentLocationToMove.transform.position) <= 1)
        {
            findNewPlaceToGo();
            moveToPlace();
        }

    }

    private void moveToPlace()
    {
        agent.SetDestination(currentLocationToMove.transform.position);
    }

    private void moveToPlayer()
    {
        agent.SetDestination(ShapeShifterScript.player.transform.position);
    }

    private void findNewPlaceToGo()
    {
        int range = Random.Range(1, 5);
        currentLocationToMove = pointOfInterest[range];
    }
}