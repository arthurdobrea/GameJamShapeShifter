using UnityEngine;

public class Booster : MonoBehaviour
{
    public GameObject character;
    public Transform point1;
    public Transform point2;
    public float boostPower;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 heading = point2.position - point1.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        character.GetComponent<Rigidbody>().AddForce(direction * boostPower);
    }

    public Vector3 GetVertexWorldPosition(Vector3 vertex, Transform owner)
    {
        return owner.localToWorldMatrix.MultiplyPoint3x4(vertex);
    }
}
