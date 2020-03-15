using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coinNumber { get; set; }

    void Start()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        coinNumber = coins.Length;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
