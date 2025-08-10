using System;
using System.Runtime.CompilerServices;
using EditorAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UIDucklingCounter : MonoBehaviour
{
    [SerializeField, Required] SO_EventManager eventManager;
    [SerializeField] private TextMeshProUGUI counterText;

    private int collectedCount = 0;
    private int totalCount;

    private void Start()
    {
        // Récupérer le total des ducklings présents au lancement
        totalCount = FindObjectsByType<DucklingCollectible>(FindObjectsSortMode.None).Length;
        
        foreach (GPI_Cacheur cacheur in FindObjectsByType<GPI_Cacheur>(FindObjectsSortMode.None))
        {
            totalCount += cacheur.ducklingNumber;
        }

        UpdateUI();
    }

    private void OnEnable()
    {
        eventManager.DispatchDucklingPickup.AddListener(UpdateCounter);
    }

    private void UpdateCounter()
    {
        collectedCount++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        counterText.text = $"{collectedCount} / {totalCount}";
    }
}
