using DG.Tweening;
using MedivalBuilder.Characters.StateMachine.Interfaces;
using UnityEngine;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterWalkState : ICharacterState
    {
        public CharacterStateType StateType { get; }

        private Transform _characterTransform;
        private float _speed;
        private Tween _moveTween;
        
        public void Init(Transform characterTransform, float speed)
        {
            _characterTransform = characterTransform;
            _speed = speed;
        }
        
        public void OnEntry()
        {
            //_moveTween = _characterTransform.DOMove()
        }

        public void OnExit()
        {
            
        }
    }
}