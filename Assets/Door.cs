using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject key;

    private bool isOpened = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, key.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (key.name == "Key")
                {
                    transform.Rotate(new Vector3(0,-85,0));
                }
            }
        }

    }
}
