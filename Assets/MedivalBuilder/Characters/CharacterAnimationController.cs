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
            _animator.SetTrigger(stateType.ToString());
        }
    }
}