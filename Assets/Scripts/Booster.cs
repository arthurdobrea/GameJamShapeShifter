using UnityEngine;

public class Booster : MonoBehaviour
{
    public GameObject player;
    public Transform point1;
    public Transform point2;
    public float boostPower;
    private Rigidbody rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player.GetComponent<CharacterController>().currentShape)
        {
            Vector3 heading = point2.position - point1.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            if (rb.velocity.magnitude < boostPower)
            {
                rb.velocity = direction * boostPower;
            }
        }
    }
}
