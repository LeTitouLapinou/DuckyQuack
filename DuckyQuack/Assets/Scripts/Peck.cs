using System;
using UnityEngine;
using UnityEngine.Audio;

public class Peck : MonoBehaviour
{
    public AudioClip[] peckSound;
    public Animator animator;


    public float radius;

    [Header("Offsets locaux")]
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public LayerMask layermask;

    RaycastHit hit;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Clic droit
        {
            Cast();
            PlaySound();

        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(peckSound[UnityEngine.Random.Range(0, peckSound.Length)]);
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
        animator.SetTrigger("PeckTrigger");
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
