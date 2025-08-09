using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    private Elevator elevator;

    void Awake()
    {
        // Va chercher le script Elevator dans le parent
        elevator = GetComponentInParent<Elevator>();
    }

    private void OnTriggerEnter(Collider other)
    {       
        elevator.duckOnElevator = true;    
    }

    private void OnTriggerExit(Collider other)
    {       
        elevator.duckOnElevator = false;   
    }
}
