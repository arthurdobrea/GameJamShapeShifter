using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class HumanWalkScript : MonoBehaviour
{
    public GameObject[] pointOfInterest;
    public GameObject placeWhereItPutsPlayer;
    public NavMeshAgent agent;
    public GameObject currentLocationToMove;

    private void Start()
    {
        findNewPlaceToGo();
        moveToPlace();
    }

    void FixedUpdate()
    {
        if (FovDetection.inFOV(transform, ShapeShifterScript.player.transform, 75, 3) && GrabAndPlacePlayer.canGrab == false
                                                                                      && (CharacterController.isMoving || ShapeShifterScript.player.transform.position.y > -0.4 ))
        {
            Debug.Log("Moving to Player");
            
            moveToPlayer();

            if (Vector3.Distance(transform.position, ShapeShifterScript.player.transform.position) < 1)
            {
                Debug.Log("Goint to grab Player");
                
                GrabAndPlacePlayer.canGrab = true;
            }
        }
        else if (GrabAndPlacePlayer.canGrab)
        {
            Debug.Log("Going to place player on table");
            
            movePlayerToTable();

            if (Vector3.Distance(transform.position, placeWhereItPutsPlayer.transform.position) < 1)
            {
                GrabAndPlacePlayer.canGrab = false;
                GrabAndPlacePlayer.canPut = true;
            }
        }
        else
        {
            Debug.Log("GoingToNewPlace");
            
            moveToPlace();
        }
        if (Vector3.Distance(transform.position, currentLocationToMove.transform.position) <= 1 && GrabAndPlacePlayer.canGrab == false)
        {
            Debug.Log("Finding New PLace To Go");
            
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

    private void movePlayerToTable()
    {
        agent.SetDestination(placeWhereItPutsPlayer.transform.position);
    }
}