using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 3f;
    public float minHeight = 0f;
    public float maxHeight = 5f;

    private bool goingUp = false;

    public bool duckOnElevator = false;

    void Update()
    {
        if (duckOnElevator) 
        { 
            // Au clic gauche, on inverse la direction
            if (Input.GetMouseButtonDown(0))
            {
                goingUp = !goingUp;
            }

            // Déplacement selon la direction
            if (goingUp)
            {
                // Monter jusqu'à maxHeight
                if (transform.position.y < maxHeight)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                    if (transform.position.y > maxHeight)
                    {
                        Vector3 pos = transform.position;
                        pos.y = maxHeight;
                        transform.position = pos;
                    }
                }
            }
            else
            {
                // Descendre jusqu'à minHeight
                if (transform.position.y > minHeight)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                    if (transform.position.y < minHeight)
                    {
                        Vector3 pos = transform.position;
                        pos.y = minHeight;
                        transform.position = pos;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        duckOnElevator = true;
    }


    private void OnTriggerExit(Collider other)
    {
       duckOnElevator = false;
    }

}
