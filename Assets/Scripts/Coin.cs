using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject vfx;
    private bool collected;
    private Vector3 scaleFactor = new Vector3(10, 10, 10);

    void FixedUpdate()
    {
        if (collected)
        {
            if (transform.localScale.y > 0)
            {
                transform.localScale -= scaleFactor * Time.deltaTime;
            }
            
        }
        transform.Rotate(new Vector3(0, 200.0f, 0) * Time.deltaTime, Space.World);
    }

    public void Collect()
    {
        collected = true;
        GameObject tempVfx = Instantiate(vfx, transform.position, Quaternion.identity) as GameObject;
        FindObjectOfType<AudioManager>().Play("CollectCoin");
        Destroy(tempVfx, 1);
        Destroy(gameObject, 0.1f);
    }
}
