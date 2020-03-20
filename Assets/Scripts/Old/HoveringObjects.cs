// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class HoveringObjects : MonoBehaviour
// {
//     public GameObject player;
//
//     // Update is called once per frame
//     void Update()
//     {
//         RaycastHit hit;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//
//         if (Input.GetMouseButtonDown(0))
//         {
//             if (Physics.Raycast(ray, out hit, 100f))
//             {
//                 Destroy(player);
//                 player = Instantiate(hit.transform, player.transform.position, Quaternion.identity).gameObject;
//                 Debug.Log(hit.transform.name);
//             }
//         }
//     }
// }