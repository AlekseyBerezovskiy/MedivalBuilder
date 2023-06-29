using System;
using System.Collections.Generic;
using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Realization;
using MedivalBuilder.Characters.StateMachine.Interfaces;
using MedivalBuilder.Characters.StateMachine.States;
using Stateless;
using Zenject;

namespace MedivalBuilder.Characters.StateMachine
{
    public class CharacterStateMachine : ICharacterStateMachine
    {
        private Dictionary<CharacterStateType, ICharacterState> _statesStorage =
            new Dictionary<CharacterStateType, ICharacterState>();
        private StateMachine<ICharacterState, CharacterStateType> _stateMachine;

        private CharacterView _characterView;
        private CharactersData _charactersData;
        private ICharacterAnimationController _characterAnimationController;
        
        private readonly IInstantiator _instantiator;
        
        public CharacterStateMachine(
            IInstantiator instantiator,
            ICharacterAnimationController characterAnimationController)
        {
            _instantiator = instantiator;
            _characterAnimationController = characterAnimationController;
            
            InitStateMachine();
        }

        public void SwitchState(CharacterStateType stateType)
        {
            _stateMachine.Fire(stateType);
        }

        public ICharacterState GetState(CharacterStateType stateType)
        {
            if (_statesStorage.ContainsKey(stateType))
            {
                return _statesStorage[stateType];
            }

            return null;
        }

        private void InitStateMachine()
        {
            var statesList = new List<ICharacterState>();
            
            var startState = CreateModuleState(CharacterStateType.Idle);
            
            _statesStorage.Add(CharacterStateType.Idle,startState);
            
            _stateMachine = new StateMachine<ICharacterState, CharacterStateType>(startState);

            statesList.Add(startState);

            var enumValues = Enum.GetValues(typeof(CharacterStateType));

            for (int i = 1; i < enumValues.Length; i++)
            {
                var moduleType = (CharacterStateType)enumValues.GetValue(i);
                
                var moduleState = CreateModuleState(moduleType);
                
                _statesStorage.Add(moduleType, moduleState);
                
                statesList.Add(moduleState);
            }

            foreach (var state in statesList)
            {
                _stateMachine.Configure(state)
                    .OnEntry(state.OnEntry)
                    .OnExit(state.OnExit);

                for (int i = 0; i < statesList.Count; i++)
                {
                    if (state.StateType == statesList[i].StateType)
                    {
                        _stateMachine.Configure(state)
                            .PermitReentry(statesList[i].StateType);
                        continue;
                    }
                    
                    _stateMachine.Configure(state)
                        .Permit((CharacterStateType)enumValues.GetValue(i), statesList[i]);
                }
            }
        }
        
        private ICharacterState CreateModuleState(CharacterStateType stateType)
        {
            var stateExtraArgs = new object[] {stateType, _characterAnimationController};
            
            switch (stateType)
            {
                case CharacterStateType.Idle:
                    return _instantiator.Instantiate<CharacterIdleState>(stateExtraArgs);
                case CharacterStateType.Walk:
                    return _instantiator.Instantiate<CharacterWalkState>(stateExtraArgs);
                case CharacterStateType.Pickup:
                    return _instantiator.Instantiate<CharacterPickupState>(stateExtraArgs);
                case CharacterStateType.Build:
                    return _instantiator.Instantiate<CharacterBuildState>(stateExtraArgs);
            }

            return null;
        }
    }

    public enum CharacterStateType
    {
        Idle,
        Walk,
        Build,
        Pickup
    }
}