using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject vfx;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 200.0f, 0) * Time.deltaTime, Space.World);
    }

    public void Collect()
    {
        vfx.SetActive(true);
        gameManager.coinNumber--;
        Debug.Log(gameManager.coinNumber);
        vfx.SetActive(true);
        vfx.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        vfx.GetComponent<Vfx>().StartCoroutine("VfxLifeTime");
        Destroy(gameObject);
    }
}
