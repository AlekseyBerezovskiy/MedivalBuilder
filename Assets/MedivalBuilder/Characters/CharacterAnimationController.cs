using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.StateMachine;
using UnityEngine;

namespace MedivalBuilder.Characters
{
    public class CharacterAnimationController : ICharacterAnimationController
    {
        private readonly Animator _animator;

        public CharacterAnimationController(
            Animator animator)
        {
            _animator = animator;
        }

        public void SetAnimation(CharacterStateType stateType)
        {
            if (stateType == CharacterStateType.Put)
            {
                stateType = CharacterStateType.Pickup;
            }

            _animator.SetTrigger(stateType.ToString());
        }
    }
}