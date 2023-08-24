using UnityEngine;

namespace MedivalBuilder.Inventory
{
    public class ItemView : MonoBehaviour
    {
        public MeshFilter MeshFilter => meshFilter;
        
        [SerializeField] private MeshFilter meshFilter;
    }
}