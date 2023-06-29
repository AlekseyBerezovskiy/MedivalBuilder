using MedivalBuilder.Characters.Interfaces;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterPickupState : CharacterState
    {
        public CharacterPickupState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }

        public override void OnEntry()
        {
           CharacterAnimationController.SetAnimation(CharacterStateType.Pickup);
        }

        public override void OnExit()
        {
            
        }
    }
}