using System;
using EditorAttributes;
using TMPro;
using UnityEngine;


public class MagicDoor : MonoBehaviour
{
    [SerializeField] private TextMeshPro counterText;
    [SerializeField] private TextMeshPro goalText;

    [SerializeField] private int goal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DucklingManager ducklingManager = other.gameObject.transform.parent.GetComponentInChildren<DucklingManager>();
        OnDuckEnter(ducklingManager.ducklingsList.Count);
        if (ducklingManager != null)
        {
            counterText.text = ducklingManager.ducklingsList.Count.ToString();
        }
    }

    private void OnDuckEnter(int ducklingsCount)
    {
        if (ducklingsCount == goal)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerExit(Collider other)
    {
        counterText.text = "0";
    }

    [Button("Update Text")]
    private void UpdateGoal()
    {
        goalText.text = goal.ToString();
    }
}
