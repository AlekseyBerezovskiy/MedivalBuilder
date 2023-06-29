using System;

namespace MedivalBuilder.Characters.StateMachine.Interfaces
{
    public interface ICharacterState
    {
        Action OnEnd { get; }
        CharacterStateType StateType { get; }
        void OnEntry();
        void OnExit();
    }
}