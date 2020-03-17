using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vfx : MonoBehaviour
{

    IEnumerator VfxLifeTime()
    {
        yield return new WaitForSeconds(.7f);
        gameObject.SetActive(false);
    }
}
