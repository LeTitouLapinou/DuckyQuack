using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Elevator : MonoBehaviour
{
    public float speed = 3f;
    public float minHeight = 0f;
    public float maxHeight = 5f;

    private bool isGoingUp = false;
    public bool duckOnElevator = false;

    [SerializeField] private GameObject lid;

    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        Vector3 pos = lid.transform.position;
        pos.y = minHeight;
        lid.transform.position = pos;
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
                if (lid.transform.position.y < maxHeight)
                {
                    lid.transform.Translate(Vector3.up * speed * Time.deltaTime);
                    isMoving = true;

                    if (lid.transform.position.y > maxHeight)
                    {
                        Vector3 pos = lid.transform.position;
                        pos.y = maxHeight;
                        lid.transform.position = pos;
                    }
                }
            }
        }
        else
        {
            // Descente automatique
            if (lid.transform.position.y > minHeight)
            {
                lid.transform.Translate(Vector3.down * speed * Time.deltaTime);
                isMoving = true;

                if (lid.transform.position.y < minHeight)
                {
                    Vector3 pos = lid.transform.position;
                    pos.y = minHeight;
                    lid.transform.position = pos;
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
