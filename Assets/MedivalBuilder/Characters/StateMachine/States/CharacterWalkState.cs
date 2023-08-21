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
        private Vector3 _targetPosition;
        
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
            
            _characterView.NavMeshAgent.SetDestination(_targetPosition);
        }

        public override void OnExit()
        {
            _characterView.NavMeshAgent.isStopped = true;
            
            _characterView.OnTriggerEnterEvent -= OnTriggerEnter;
        }

        public void SetParameters(Vector3 targetPosition, Action onEnd)
        {
            OnEnd += onEnd;
            _targetPosition = targetPosition;
        }

        private void OnTriggerEnter(Collider collision)
        {
            OnEnd?.Invoke();
        }
    }
}