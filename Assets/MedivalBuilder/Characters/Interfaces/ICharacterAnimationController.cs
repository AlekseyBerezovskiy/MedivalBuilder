using MedivalBuilder.Characters.StateMachine;

namespace MedivalBuilder.Characters.Interfaces
{
    public interface ICharacterAnimationController
    {
        void SetAnimation(CharacterStateType stateType);
    }
}