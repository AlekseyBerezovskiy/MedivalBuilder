using MedivalBuilder.Characters.Interfaces;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterBuildState : CharacterState
    {
        public CharacterBuildState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }

        public override void OnEntry()
        {
            CharacterAnimationController.SetAnimation(CharacterStateType.Build);
        }

        public override void OnExit()
        {
            
        }
    }
}