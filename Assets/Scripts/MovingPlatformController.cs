﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public GameObject player;
    public Vector3[] points;
    public int pointNumber = 0;
    private Vector3 currentTarget;
    public float tolerance;
    public float speed;
    public float delayTime;
    public float delayStart;
    public bool automatic;

    void Start()
    {
        if(points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    void Update()
    {
        if(transform.position != currentTarget)
        {
            MovePlatform();
        } else
        {
            UpdateTarget();
        }
    }

    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if(heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if(Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }
    }

    void NextPlatform()
    {
        pointNumber++;
        if(pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player.GetComponent<CharacterController>().currentShape)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.GetComponent<CharacterController>().currentShape)
        {
            player.transform.parent = null;
        }
    }
}