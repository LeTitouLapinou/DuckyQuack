using EditorAttributes;
using UnityEngine;

public class Quack : MonoBehaviour
{
    [SerializeField, Required] SO_EventManager eventManager;

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
            eventManager.DuckQuacked.Invoke();
        }
    }
}
