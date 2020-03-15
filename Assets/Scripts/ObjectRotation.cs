using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 200.0f, 0) * Time.deltaTime, Space.World);
    }
}
