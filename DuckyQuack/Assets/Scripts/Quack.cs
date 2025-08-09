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

        audioSource.clip = quackSound;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))  // 1 = clic droit (0 = clic gauche)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
