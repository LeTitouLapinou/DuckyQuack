using EditorAttributes;
using UnityEngine;

public class Quack : MonoBehaviour
{
    [SerializeField, Required] SO_EventManager eventManager;

    public AudioClip[] quackSound;
    private AudioSource audioSource;

    [SerializeField] private ParticleSystem peckParticles;
    [SerializeField] private GameObject cameraGO;

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
        if (Input.GetMouseButtonDown(0))  // 0 = clic gauche
        {
            peckParticles.Stop();
            audioSource.PlayOneShot(quackSound[Random.Range(0, quackSound.Length)]);
            eventManager.DuckQuacked.Invoke();

            peckParticles.Play();
        }
        peckParticles.gameObject.transform.rotation = cameraGO.transform.rotation * Quaternion.Euler(0, 180f, 0);
    }
}
