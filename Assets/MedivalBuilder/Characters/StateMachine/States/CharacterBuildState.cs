using System;
using DG.Tweening;
using MedivalBuilder.Characters.Interfaces;
using UnityEngine;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterBuildState : CharacterState
    {
        private float _timeToDone;
        private Tween _delayTween;
        
        public CharacterBuildState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }

        public override void OnEntry()
        {
            CharacterAnimationController.SetAnimation(CharacterStateType.Build);

            _delayTween = DOVirtual.DelayedCall(_timeToDone, () =>
            {
                OnEnd?.Invoke();
            });
        }

        public override void OnExit()
        {
            _delayTween?.Kill();
            _delayTween = null;
        }

        public void SetParameters(float timeToDone, Action onEnd)
        {
            OnEnd += onEnd;
            _timeToDone = timeToDone;
        }
    }
}