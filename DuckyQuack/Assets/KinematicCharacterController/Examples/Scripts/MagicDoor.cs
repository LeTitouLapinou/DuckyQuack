using System;
using System.Collections;
using EditorAttributes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class MagicDoor : MonoBehaviour
{
    [Title("Value to change")]
    [SerializeField] private int goal;

    [Button("Update Text", 30)]
    private void UpdateGoal()
    {
        goalText.text = goal.ToString();
    }

    [Space(20)]
    [SerializeField] private TextMeshPro counterText;
    [SerializeField] private TextMeshPro goalText;
    [SerializeField] private Animation doorHingeAnim;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite panelGoodSprite;
    private bool doorClosed = true;

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
        if (ducklingsCount >= goal && doorClosed)
        { 
            StartCoroutine("OpenDoor");
        }
    }

    IEnumerator OpenDoor()
    {
        doorClosed = false;
        spriteRenderer.sprite = panelGoodSprite;
        yield return new WaitForSeconds(.5f);
        doorHingeAnim.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        counterText.text = "0";
    }


}
