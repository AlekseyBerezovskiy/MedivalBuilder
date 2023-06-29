using MedivalBuilder.Characters.Interfaces;

namespace MedivalBuilder.Characters.StateMachine.Interfaces
{
    public interface ICharacterState
    {
        CharacterStateType StateType { get; }
        ICharacterAnimationController CharacterAnimationController { get; }
        void OnEntry();
        void OnExit();
    }
}