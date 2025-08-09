using UnityEngine;

public class DucklingPosRandomizer : MonoBehaviour
{
    [SerializeField] private float amplitude;
    void Awake()
    {
        //gameObject.transform.SetPositionAndRotation(new Vector3(Random.Range(0, amplitude/2), 0, Random.Range(-amplitude, amplitude)), transform.rotation);
    }


}
