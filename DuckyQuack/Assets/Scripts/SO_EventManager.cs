using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SO_EventManager", menuName = "SO_EventManager")]
public class SO_EventManager : ScriptableObject
{
    public UnityEvent<SO_Duckling> DucklingPickedUp;
    public UnityEvent DispatchDucklingPickup;
}
