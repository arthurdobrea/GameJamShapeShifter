using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShift : MonoBehaviour
{
    public GameObject sphere;
    public GameObject cube;

    void Start()
    {
        sphere.SetActive(true);
        cube.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            sphere.SetActive(!sphere.activeSelf);
            cube.SetActive(!cube.activeSelf);
        }
    }
}
