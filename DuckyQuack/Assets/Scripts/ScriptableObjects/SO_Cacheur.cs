using EditorAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Cacheur", menuName = "GPI/SO_Cacheur")]
public class SO_Cacheur : ScriptableObject
{
    public Mesh mesh;

    //public Material initialMaterial;
    //public Material swappedMaterial;

    [Title("Number of ducklings")]
    public int ducklingNumber;
}
