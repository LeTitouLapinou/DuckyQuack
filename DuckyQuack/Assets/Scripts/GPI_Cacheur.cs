using EditorAttributes;
using UnityEngine;

[ExecuteInEditMode]
public class GPI_Cacheur : MonoBehaviour
{
    
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


    [Button("Update mesh")]
    private void UpdateMesh()
    {
        meshFilter.mesh = mesh;
    }
}
