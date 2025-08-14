using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SO_EventManager eventManager;

    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        eventManager.DucklingPickedUp.AddListener(DucklingPickup);
    }

    private void DucklingPickup(SO_Duckling duckling)
    {
        audioSource.clip = duckling.ducklingClip;
        audioSource.Play();
    }

}
