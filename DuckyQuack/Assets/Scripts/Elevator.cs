using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 3f;
    public float minHeight = 0f;
    public float maxHeight = 5f;

    private bool isGoingUp = false;
    public bool duckOnElevator = false;

    void Update()
    {
        if (duckOnElevator)
        {
            // Si on est sur l'ascenseur et clic gauche, on monte
            if (Input.GetMouseButtonDown(0))
            {
                isGoingUp = true;
            }

            // Si on est sur l'ascenseur et on monte
            if (isGoingUp)
            {
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
                // Si on est sur l'ascenseur mais on ne monte pas, on reste immobile
                // (ne rien faire)
            }
        }
        else
        {
            // Si on n'est pas sur l'ascenseur, on descend automatiquement
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

            // Une fois en bas, on arrête la montée
            isGoingUp = false;
        }
    }
}
