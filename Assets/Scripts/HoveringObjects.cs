using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringObjects : MonoBehaviour
{
    public GameObject player;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Destroy(player);
                player = Instantiate(hit.transform, player.transform.position, Quaternion.identity).gameObject;
                player.AddComponent<Rigidbody>();
                Debug.Log(hit.transform.name);
            }
        }
    }
}