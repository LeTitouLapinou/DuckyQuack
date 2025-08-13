using UnityEngine;

public class RoastedDuckFlight : MonoBehaviour
{
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(-1,1), 5, Random.Range(-1, 1)), ForceMode.Impulse);
        transform.rotation = Random.rotation;
    }

}
