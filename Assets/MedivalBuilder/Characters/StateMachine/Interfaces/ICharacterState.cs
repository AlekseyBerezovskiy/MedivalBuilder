namespace MedivalBuilder.Characters.StateMachine.Interfaces
{
    public interface ICharacterState
    {
        CharacterStateType StateType { get; }
        void OnEntry();
        void OnExit();
    }
}