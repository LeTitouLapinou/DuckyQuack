using UnityEngine;

public class Quack : MonoBehaviour
{
    public AudioClip quackSound;
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
        if (Input.GetMouseButtonDown(1))  // 1 = clic droit
        {
            audioSource.PlayOneShot(quackSound);
        }
    }
}
