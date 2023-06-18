namespace MedivalBuilder.Characters.StateMachine.Interfaces
{
    public interface ICharacterStateMachine
    {
        void SwitchState(CharacterStateType stateType);
    }
}