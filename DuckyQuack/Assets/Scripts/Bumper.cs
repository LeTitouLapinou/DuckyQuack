using KinematicCharacterController.Examples;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ExampleCharacterController>()?.AddVelocity(Vector3.up *  bounceForce);
    }
}
