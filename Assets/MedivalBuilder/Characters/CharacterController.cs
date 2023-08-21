﻿using System;
using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Inventory;
using MedivalBuilder.Characters.Realization;
using MedivalBuilder.Characters.StateMachine;
using MedivalBuilder.Characters.StateMachine.Interfaces;
using MedivalBuilder.Characters.StateMachine.States;
using MedivalBuilder.Inventory;
using UnityEngine;

namespace MedivalBuilder.Characters
{
    public class CharacterController : ICharacterController
    {
        private readonly ICharacterStateMachine _characterStateMachine;
        private readonly CharacterView _characterView;

        private CharacterWalkState _characterWalkState;
        private CharacterBuildState _characterBuildState;
        private CharacterPickupState _characterPickupState;
        private CharacterInventory _characterInventory;
        
        public CharacterController(
            ICharacterStateMachine characterStateMachine,
            CharacterView characterView,
            CharactersData charactersData)
        {
            _characterStateMachine = characterStateMachine;
            _characterView = characterView;

            _characterInventory = new CharacterInventory();
            
            Init(charactersData);
        }
        
        public void SetWalk(Vector3 targetPosition, Action onEnd)
        {
            _characterWalkState.SetParameters(targetPosition, onEnd);

            _characterStateMachine.SwitchState(CharacterStateType.Walk);
        }

        public void SetIdle()
        {
            _characterStateMachine.SwitchState(CharacterStateType.Idle);
        }

        public void SetBuild(float time, Action onEnd)
        {
            _characterBuildState.SetParameters(time, onEnd);
            _characterStateMachine.SwitchState(CharacterStateType.Build);
        }

        public void SetPickup(Item item, Action onEnd)
        {
            _characterPickupState.SetParameters(item, onEnd);
            _characterStateMachine.SwitchState(CharacterStateType.Pickup);
        }

        private void Init(CharactersData charactersData)
        {
            _characterBuildState = _characterStateMachine.GetState(CharacterStateType.Build) as CharacterBuildState;
            
            _characterPickupState = _characterStateMachine.GetState(CharacterStateType.Pickup) as CharacterPickupState;
            _characterPickupState.Init(_characterInventory);
            
            _characterWalkState = _characterStateMachine.GetState(CharacterStateType.Walk) as CharacterWalkState;
            _characterWalkState.Init(_characterView, charactersData);
        }
    }
}