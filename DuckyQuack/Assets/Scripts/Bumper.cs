using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Debug.Log(rb);
        rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    }
}
