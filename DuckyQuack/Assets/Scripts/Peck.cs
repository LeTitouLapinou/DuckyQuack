using UnityEngine;

public class Peck : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public GameObject spherePreview;

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
            animator.SetTrigger("Peck");
            Cast();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 spherePos = transform.position
                            + transform.forward * offsetX
                            + transform.up * offsetY
                            + transform.right * offsetZ;
        Gizmos.DrawSphere(spherePos, radius);
    }

    void Cast()
    {

        Vector3 origin = transform.position
                         + transform.forward * offsetX
                         + transform.up * offsetY
                         + transform.right * offsetZ;

        Vector3 direction = transform.forward; 
        float maxDistance = radius/2f;

        Collider[] hitColliders = Physics.OverlapSphere(origin, radius, layermask);

        foreach (Collider collider in hitColliders)
        {
            Debug.Log(collider.name);
            collider.gameObject.GetComponentInParent<IPeckable>()?.OnPeck();
        }
    }
}
