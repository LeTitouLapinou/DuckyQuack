using System;
using System.Collections;
using EditorAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class DucklingQuack : MonoBehaviour
{
    [SerializeField, Required] SO_EventManager eventManager;
    [SerializeField, Required] AudioSource audioSource;
    [SerializeField] Animation quackAnim;

    private void OnEnable()
    {
        eventManager.DuckQuacked.AddListener(OnDuckQuack);
    }

    private void OnDuckQuack()
    {
        StartCoroutine("PlaySoundWithDelay");
    }

    IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(Random.Range(0.3f, 0.6f));
        audioSource.Play();
        quackAnim.Play();

    }


}
