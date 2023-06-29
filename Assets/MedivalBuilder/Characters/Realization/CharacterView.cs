using System;
using UnityEngine;
using UnityEngine.AI;

namespace MedivalBuilder.Characters.Realization
{
    public class CharacterView : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEnterEvent;
        
        public Animator Animator => animator;
        public NavMeshAgent NavMeshAgent => navMeshAgent;
        
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }
    }
}