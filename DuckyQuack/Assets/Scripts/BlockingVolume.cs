using UnityEngine;

public class BlockingVolume : MonoBehaviour
{
    void Start()
    {
        // Désactive le MeshRenderer pour rendre la capsule invisible
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
    }

    void Update()
    {

    }
}
