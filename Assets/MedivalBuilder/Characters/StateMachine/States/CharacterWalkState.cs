using System;
using DG.Tweening;
using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Realization;
using UnityEngine;

namespace MedivalBuilder.Characters.StateMachine.States
{
    public class CharacterWalkState : CharacterState
    {
        public event Action OnEndWalkEvent;
        
        private CharacterView _characterView;
        private CharactersData _charactersData;
        private Tween _moveTween;
        private Vector3 _targetPosition;
        
        public CharacterWalkState(
            CharacterStateType characterStateType,
            ICharacterAnimationController characterAnimationController) 
            : base(characterStateType, characterAnimationController)
        { }
        
        public void Init(
            CharacterView characterView, 
            CharactersData charactersData)
        {
            _characterView = characterView;
            _charactersData = charactersData;
        }
        
        public override void OnEntry()
        {
            if (_targetPosition != Vector3.zero)
            {
                CharacterAnimationController.SetAnimation(CharacterStateType.Walk);
                
                _moveTween = _characterView.transform.DOMove(
                    _targetPosition,
                    Vector3.Distance(
                        _characterView.transform.position, 
                        _targetPosition) 
                    * _charactersData.Speed)
                    .OnComplete(() =>
                    {
                        OnEndWalkEvent?.Invoke();
                    });
            }
        }

        public override void OnExit()
        {
            _targetPosition = Vector3.zero;
            
            _moveTween?.Kill();
            _moveTween = null;
        }

        public void SetTarget(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }
}