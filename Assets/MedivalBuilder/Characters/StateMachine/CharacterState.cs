using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.StateMachine.Interfaces;

namespace MedivalBuilder.Characters.StateMachine
{
    public abstract class CharacterState : ICharacterState
    {
        public CharacterStateType StateType { get; }
        public ICharacterAnimationController CharacterAnimationController { get; }
        
        public CharacterState(
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