using System;
using DG.Tweening;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Inventory;
using MedivalBuilder.Inventory;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterPickupState : CharacterState
    {
        private const float PickupDelay = 3f;

        private Tween _delayTween;
        private Item _item;
        private CharacterInventory _characterInventory; 

        public CharacterPickupState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }

        public override void OnEntry()
        {
           CharacterAnimationController.SetAnimation(CharacterStateType.Pickup);

           _delayTween = DOVirtual.DelayedCall(PickupDelay, () =>
           {
               _characterInventory.Item = _item;

               _item = null;
               
               OnEnd?.Invoke();
           });
        }

        public override void OnExit()
        {
            _delayTween?.Kill();
            _delayTween = null;
        }

        public void Init(CharacterInventory characterInventory)
        {
            _characterInventory = characterInventory;
        }
        
        public void SetParameters(Item item, Action onEnd)
        {
            OnEnd = onEnd;
            _item = item;
        }
    }
}