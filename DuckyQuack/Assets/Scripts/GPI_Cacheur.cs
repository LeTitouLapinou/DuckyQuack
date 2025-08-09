using System.Collections;
using EditorAttributes;
using UnityEngine;

[ExecuteInEditMode]
public class GPI_Cacheur : MonoBehaviour
{
    [SerializeField, Required] private GameObject collectiblePrefab;

    [SerializeField, Required] private Mesh mesh;
    public int ducklingNumber;

    //[SerializeField, Required] private SO_EventManager eventManager;

    [FoldoutGroup("References", nameof(meshFilter), nameof(meshRenderer), nameof(initialMaterial), nameof(swappedMaterial))]
    [SerializeField] private Void groupHolder;
    [SerializeField, HideProperty] private MeshFilter meshFilter;
    [SerializeField, HideProperty] private MeshRenderer meshRenderer;
    [Space(10)]
    [SerializeField, HideProperty] private Material initialMaterial;
    [SerializeField, HideProperty] private Material swappedMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [Button("Spawn ducklings")]
    private void StartCoroutineDuck()
    {
        StartCoroutine("SpawnDucklings");
        meshRenderer.material = swappedMaterial;
    }

    IEnumerator SpawnDucklings()
    {
        for (int i = 0; i < ducklingNumber; i++)
        {
            GameObject duckling = Instantiate(collectiblePrefab, transform.position, transform.rotation);
            Vector3 randomTilt = (Vector3.up + Random.insideUnitSphere * 0.8f).normalized;
            duckling.GetComponent<Rigidbody>()?.AddForce(randomTilt * 300f);
            yield return new WaitForSeconds(.1f);
        }
    }

    [Button("Update mesh")]
    private void UpdateMesh()
    {
        meshFilter.mesh = mesh;
    }
}
