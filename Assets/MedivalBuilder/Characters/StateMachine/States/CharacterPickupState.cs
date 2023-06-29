using DG.Tweening;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Inventory;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterPickupState : CharacterState
    {
        private const float PickupDelay = 3f;

        private Tween _delayTween;
        private Item _item;
        
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
               OnEnd?.Invoke();
           });
        }

        public override void OnExit()
        {
            _delayTween?.Kill();
            _delayTween = null;
        }

        public void SetItem(Item item)
        {
            _item = item;
        }
    }
}