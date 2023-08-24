using MedivalBuilder.SceneObjectsStorage;
using UnityEngine;

namespace MedivalBuilder.Level
{
    public class LevelView : SceneObject
    {
        public Transform[] WoodItemAnchors => woodItemAnchors;
        public Transform[] StoneItemAnchors => stoneItemAnchors;
        
        [SerializeField] private Transform[] woodItemAnchors;
        [SerializeField] private Transform[] stoneItemAnchors;
    }
}
