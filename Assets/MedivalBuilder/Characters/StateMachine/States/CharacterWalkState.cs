using System;
using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Realization;
using UnityEngine;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterWalkState : CharacterState
    {
        private CharacterView _characterView;
        private Transform _targetTransform;
        
        public CharacterWalkState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }
        
        public void Init(
            CharacterView characterView, 
            CharactersData charactersData)
        {
            _characterView = characterView;

            _characterView.NavMeshAgent.speed = charactersData.Speed;
            _characterView.NavMeshAgent.angularSpeed = charactersData.AngularSpeed;
        }
        
        public override void OnEntry()
        {
            CharacterAnimationController.SetAnimation(CharacterStateType.Walk);

            _characterView.OnTriggerEnterEvent += OnTriggerEnter;
            
            _characterView.NavMeshAgent.isStopped = false;
            
            _characterView.NavMeshAgent.SetDestination(_targetTransform.position);
        }

        public override void OnExit()
        {
            OnEnd = null;
            
            _characterView.NavMeshAgent.isStopped = true;
            
            _characterView.OnTriggerEnterEvent -= OnTriggerEnter;
        }

        public void SetParameters(Transform targetTransform, Action onEnd)
        {
            OnEnd += onEnd;
            _targetTransform = targetTransform;
        }

        private void OnTriggerEnter(Collider collision)
        {
            var a = collision.transform.GetInstanceID();
            var b = _targetTransform.GetInstanceID();
            
            if (collision.transform.GetInstanceID() == _targetTransform.GetInstanceID())
            {
                OnEnd?.Invoke();
            }
        }
    }
}