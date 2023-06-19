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
        private readonly ICharacterAnimationController _characterAnimationController;
        private readonly CharacterView _characterView;

        public CharacterController(
            ICharacterStateMachine characterStateMachine,
            ICharacterAnimationController characterAnimationController,
            CharacterView characterView,
            CharactersData charactersData)
        {
            _characterStateMachine = characterStateMachine;
            _characterAnimationController = characterAnimationController;
            _characterView = characterView;

            Init(charactersData);
        }
        
        public void SetWalk(Vector3 targetPosition)
        {
            _characterAnimationController.SetAnimation(CharacterStateType.Walk);
            _characterStateMachine.SwitchState(CharacterStateType.Walk);
        }

        public void SetIdle()
        {
            _characterAnimationController.SetAnimation(CharacterStateType.Idle);
            _characterStateMachine.SwitchState(CharacterStateType.Idle);
        }

        public void SetBuild(float time)
        {
            _characterAnimationController.SetAnimation(CharacterStateType.Build);
            _characterStateMachine.SwitchState(CharacterStateType.Build);
        }

        public void SetPickup(Item item)
        {
            _characterAnimationController.SetAnimation(CharacterStateType.Pickup);
            _characterStateMachine.SwitchState(CharacterStateType.Pickup);
        }

        private void Init(CharactersData charactersData)
        {
            var walkState = _characterStateMachine.GetState(CharacterStateType.Walk) as CharacterWalkState;
            walkState?.Init(_characterView.transform, charactersData.Speed);
        }
    }
}