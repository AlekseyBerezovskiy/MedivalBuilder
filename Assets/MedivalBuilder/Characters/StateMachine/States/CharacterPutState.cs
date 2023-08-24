using System;
using DG.Tweening;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Inventory;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterPutState : CharacterState
    {
        private const float PutDelay = 3f;

        private Tween _delayTween;
        private CharacterInventory _characterInventory; 
        
        public CharacterPutState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }

        public override void OnEntry()
        {
            CharacterAnimationController.SetAnimation(CharacterStateType.Put);

            _delayTween = DOVirtual.DelayedCall(PutDelay, () =>
            {
                _characterInventory.Item = null;

                OnEnd?.Invoke();
            });
        }

        public override void OnExit()
        {
            OnEnd = null;
            
            _delayTween?.Kill();
            _delayTween = null;
        }

        public void Init(CharacterInventory characterInventory)
        {
            _characterInventory = characterInventory;
        }
        
        public void SetParameters(Action onEnd)
        {
            OnEnd = onEnd;
        }
    }
}