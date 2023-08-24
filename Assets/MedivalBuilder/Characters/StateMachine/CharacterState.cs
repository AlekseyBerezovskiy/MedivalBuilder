using System;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.StateMachine.Interfaces;

namespace MedivalBuilder.Characters.StateMachine
{
    public abstract class CharacterState : ICharacterState
    {
        public Action OnEnd { protected set; get; }
        public CharacterStateType StateType { get; }
        protected ICharacterAnimationController CharacterAnimationController { get; }

        protected CharacterState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController)
        {
            StateType = characterStateType;
            CharacterAnimationController = characterAnimationController;
        }

        public abstract void OnEntry();
        public abstract void OnExit();
    }
}