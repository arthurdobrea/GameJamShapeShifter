using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 offset;
    public GameObject playerToFollow;
    public float smoothSpeed = 1;
    public float speed;
    private Rigidbody rigidbody;

    public void Start()
    {
        rigidbody = playerToFollow.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Vector3 desiredPoistion = playerToFollow.transform.position + offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPoistion, smoothSpeed);
        transform.position = smoothedPostion;

        transform.LookAt(playerToFollow.transform);
    }
}