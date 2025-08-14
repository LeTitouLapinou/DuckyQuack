using System.Collections;
using EditorAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DucklingCollectible : MonoBehaviour
{
    [SerializeField, Required] SO_EventManager eventManager;
    [SerializeField, Required] SO_Duckling SO_duckling;

    private bool canBePickedUp = false;

    private void Start()
    {
        StartCoroutine("EnablePickup");

    }

    public void OnPickup()
    {
        eventManager.DucklingPickedUp.Invoke(SO_duckling);
        eventManager.DispatchDucklingPickup.Invoke(); // Event de ramassage de duckling pour UI
        Destroy(gameObject);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (canBePickedUp)
        {
            OnPickup();
        }
    }

    IEnumerator EnablePickup()
    {
        yield return new WaitForSeconds(1);
        canBePickedUp = true;
    }
}
