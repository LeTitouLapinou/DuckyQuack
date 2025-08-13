using System.Collections;
using EditorAttributes;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class GPI_Cacheur : MonoBehaviour, IPeckable
{
    public UnityEvent ePecked;

    [SerializeField, Required] private Mesh mesh;
    public int ducklingNumber;

    private GameObject playerRef;

    //[SerializeField, Required] private SO_EventManager eventManager;

    [FoldoutGroup("References",nameof(particleSys), nameof(collectiblePrefab), nameof(meshFilter), nameof(meshRenderer), nameof(meshCollider), nameof(initialMaterial), nameof(swappedMaterial))]
    [SerializeField] private Void groupHolder;
    [SerializeField, HideProperty] private ParticleSystem particleSys;
    [SerializeField, HideProperty] private GameObject collectiblePrefab;
    [SerializeField, HideProperty] private MeshFilter meshFilter;
    [SerializeField, HideProperty] private MeshRenderer meshRenderer;
    [SerializeField, HideProperty] private MeshCollider meshCollider;
    [Space(10)]
    [SerializeField, HideProperty] private Material initialMaterial;
    [SerializeField, HideProperty] private Material swappedMaterial;

    private bool canBePicked = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void StartCoroutineDuck()
    {
        canBePicked = false;
        StartCoroutine("SpawnDucklings");
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
        meshCollider.sharedMesh = mesh;
    }

    public void OnPeck(GameObject sender)
    {
        if (canBePicked)
        {
            StartCoroutineDuck();
            playerRef = sender;
            ePecked.Invoke();
        }
    }

    public void RoastTheDuck(GameObject roastedDuckPrefab)
    {
        Instantiate(roastedDuckPrefab, playerRef.transform.position, Quaternion.identity);
        playerRef.gameObject.SetActive(false);
        
    }
}
