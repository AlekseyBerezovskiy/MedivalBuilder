using MedivalBuilder.Characters.Interfaces;
using Zenject;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterIdleState : CharacterState, ITickable
    {
        private readonly TickableManager _tickableManager;

        public CharacterIdleState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController,
            TickableManager tickableManager) 
            : base(characterStateType, characterAnimationController)
        {
            _tickableManager = tickableManager;
        }

        public override void OnEntry()
        {
            CharacterAnimationController.SetAnimation(CharacterStateType.Idle);
            
            _tickableManager.Add(this);
        }

        public override void OnExit()
        {
            _tickableManager.Remove(this);
        }

        public void Tick()
        {
            OnEnd?.Invoke();
        }
    }
}