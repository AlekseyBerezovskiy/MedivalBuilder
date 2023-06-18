using MedivalBuilder.Characters.StateMachine.Interfaces;

namespace MedivalBuilder.Characters.StateMachine
{
    public class CharacterState : ICharacterState
    {
        public CharacterStateType StateType { get; }

        public CharacterState(
            CharacterStateType characterStateType)
        {
            StateType = characterStateType;
        }
        
        public void OnEntry()
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}