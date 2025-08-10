using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Elevator : MonoBehaviour
{
    public float speed = 3f;
    public float minHeight = 0f;
    public float maxHeight = 5f;

    private bool isGoingUp = false;
    public bool duckOnElevator = false;

    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        Vector3 pos = transform.position;
        pos.y = minHeight;
        transform.position = pos;
    }


    void Update()
    {
        bool wasMoving = isMoving;
        isMoving = false; // on réinitialise à chaque frame

        if (duckOnElevator)
        {
            // Clic gauche => monte
            if (Input.GetMouseButtonDown(0))
            {
                isGoingUp = true;
            }

            if (isGoingUp)
            {
                if (transform.position.y < maxHeight)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                    isMoving = true;

                    if (transform.position.y > maxHeight)
                    {
                        Vector3 pos = transform.position;
                        pos.y = maxHeight;
                        transform.position = pos;
                    }
                }
            }
        }
        else
        {
            // Descente automatique
            if (transform.position.y > minHeight)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                isMoving = true;

                if (transform.position.y < minHeight)
                {
                    Vector3 pos = transform.position;
                    pos.y = minHeight;
                    transform.position = pos;
                }
            }

            isGoingUp = false;
        }

        // Gestion du son en fonction du mouvement
        if (isMoving && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!isMoving && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
