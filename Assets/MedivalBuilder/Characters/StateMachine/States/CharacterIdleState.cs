using MedivalBuilder.Characters.StateMachine.Interfaces;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterIdleState : ICharacterState
    {
        public CharacterStateType StateType { get; }
        
        public CharacterIdleState(CharacterStateType stateType)
        {
            StateType = stateType;
        }

        public void OnEntry()
        {
            
        }

        public void OnExit()
        {
           
        }
    }
}