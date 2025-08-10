using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

public class DucklingManager : MonoBehaviour
{
    [SerializeField, Required] SO_EventManager eventManager;
    [SerializeField, Required] Transform playerTransform;


    public List<GameObject> ducklingsList = new List<GameObject>();

    private void OnEnable()
    {
        eventManager.DucklingPickedUp.AddListener(AddDucklingToList);
    }

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void AddDucklingToList(SO_Duckling newDuckling)
    {
        GameObject duckling = Instantiate(newDuckling.ducklingPrefab, transform);
        DucklingMovement ducklingMovement = duckling.AddComponent<DucklingMovement>();

        ducklingsList.Add(duckling);
        SetDucklingTarget(ducklingMovement, ducklingsList.IndexOf(duckling));
        

    }

    private void SetDucklingTarget(DucklingMovement ducklingMovement, int indexOfDuckling)
    {
        Debug.Log(indexOfDuckling);
        if (indexOfDuckling == 0) //|| indexOfDuckling == 8
        {
            ducklingMovement.follow = playerTransform;
        }
        else
        {
            ducklingMovement.follow = ducklingsList[indexOfDuckling-1].transform;
        }
            
    }
}
