using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoving : MonoBehaviour
{
    public float speed;

    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(Vector3.right * (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(Vector3.left * (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.back * (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector3.forward  * (speed * Time.deltaTime));
        }
    }
}