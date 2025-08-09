using EditorAttributes;
using UnityEngine;

public class DucklingCollectible : MonoBehaviour
{
    [SerializeField, Required] SO_EventManager eventManager;
    [SerializeField, Required] SO_Duckling SO_duckling;

    [Button("Add duckling")]
    public void OnPickup()
    {
        eventManager.DucklingPickedUp.Invoke(SO_duckling);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        OnPickup();

    }
}
