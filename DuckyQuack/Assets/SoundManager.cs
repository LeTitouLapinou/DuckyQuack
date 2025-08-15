using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public SO_EventManager eventManager;
    
    private int indexDucklingSound = 0;

    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        eventManager.DucklingPickedUp.AddListener(DucklingPickup);
    }

    private void DucklingPickup(SO_Duckling duckling)
    {
        audioSource.clip = duckling.ducklingAudioClips[indexDucklingSound];
        audioSource.Play();
        indexDucklingSound++;
        if (indexDucklingSound == 4)
            indexDucklingSound = 0;
    }

}
