using MedivalBuilder.Characters.Interfaces;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterIdleState : CharacterState
    {
        public CharacterIdleState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }

        public override void OnEntry()
        {
            CharacterAnimationController.SetAnimation(CharacterStateType.Idle);
        }

        public override void OnExit()
        {
            
        }
    }
}