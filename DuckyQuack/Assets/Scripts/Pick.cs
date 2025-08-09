using UnityEngine;

public class Pick : MonoBehaviour
{
    public float radius;
    public float maxDistance;

    [Header("Offsets locaux")]
    public float offsetX;  
    public float offsetY;  
    public float offsetZ; 

    public LayerMask layermask;

    RaycastHit hit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

        // Direction du SphereCast : vers le bas local (tu peux modifier si besoin)
        Vector3 direction = -transform.up;

        if (Physics.SphereCast(origin, radius, direction, out hit, maxDistance, layermask))
        {
            Debug.Log(hit.collider.gameObject);
        }
    }
}
