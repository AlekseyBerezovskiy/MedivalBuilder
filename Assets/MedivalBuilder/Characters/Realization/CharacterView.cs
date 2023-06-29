using UnityEngine;

namespace MedivalBuilder.Characters.Realization
{
    public class CharacterView : MonoBehaviour
    {
        public Animator Animator => animator;
        
        [SerializeField] private Animator animator;
    }
}