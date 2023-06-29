using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Inventory;
using MedivalBuilder.Characters.Realization;
using MedivalBuilder.Characters.StateMachine;
using MedivalBuilder.Characters.StateMachine.Interfaces;
using MedivalBuilder.Characters.StateMachine.States;
using UnityEngine;

namespace MedivalBuilder.Characters
{
    public class CharacterController : ICharacterController
    {
        private readonly ICharacterStateMachine _characterStateMachine;
        private readonly CharacterView _characterView;

        private CharacterWalkState _characterWalkState;
        
        public CharacterController(
            ICharacterStateMachine characterStateMachine,
            CharacterView characterView,
            CharactersData charactersData)
        {
            _characterStateMachine = characterStateMachine;
            _characterView = characterView;
            
            Init(charactersData);
        }
        
        public void SetWalk(Vector3 targetPosition)
        {
            _characterWalkState.SetTarget(targetPosition);
           
            _characterStateMachine.SwitchState(CharacterStateType.Walk);
        }

        public void SetIdle()
        {
            _characterStateMachine.SwitchState(CharacterStateType.Idle);
        }

        public void SetBuild(float time)
        {
            _characterStateMachine.SwitchState(CharacterStateType.Build);
        }

        public void SetPickup(Item item)
        {
            _characterStateMachine.SwitchState(CharacterStateType.Pickup);
        }

        private void Init(CharactersData charactersData)
        {
            _characterWalkState = _characterStateMachine.GetState(CharacterStateType.Walk) as CharacterWalkState;
            _characterWalkState.Init(_characterView, charactersData);
        }
    }
}