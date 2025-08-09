using UnityEngine;

public class Peck : MonoBehaviour, IPeckable
{
    public float radius;

    [Header("Offsets locaux")]
    public float offsetX;  
    public float offsetY;  
    public float offsetZ; 

    public LayerMask layermask;

    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic gauche
        {
            Cast();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Position décalée dans les 3 axes locaux
        Vector3 spherePos = transform.position
                            + transform.right * offsetX
                            + transform.up * offsetY
                            + transform.forward * offsetZ;
        Gizmos.DrawSphere(spherePos, radius);
    }

    void Cast()
    {
        Vector3 origin = transform.position
                         + transform.right * offsetX
                         + transform.up * offsetY
                         + transform.forward * offsetZ;
        Vector3 direction = -transform.up;

    }

    void IPeckable.OnPeck()
    {
        //tofill
    }
}
