using System;
using System.Collections.Generic;
using MedivalBuilder.Characters.StateMachine.Interfaces;
using Stateless;
using Zenject;

namespace MedivalBuilder.Characters.StateMachine
{
    public class CharacterStateMachine : ICharacterStateMachine
    {
        private StateMachine<ICharacterState, CharacterStateType> _stateMachine;
        
        private readonly IInstantiator _instantiator;
        
        public CharacterStateMachine(IInstantiator instantiator)
        {
            _instantiator = instantiator;
            
            InitStateMachine();
        }

        public void SwitchState(CharacterStateType stateType)
        {
            _stateMachine.Fire(stateType);
        }

        private void InitStateMachine()
        {
            var statesList = new List<ICharacterState>();
            
            var startState = CreateModuleState(CharacterStateType.Idle);

            _stateMachine = new StateMachine<ICharacterState, CharacterStateType>(startState);

            statesList.Add(startState);

            var enumValues = Enum.GetValues(typeof(CharacterStateType));

            for (int i = 1; i < enumValues.Length; i++)
            {
                var moduleType = (CharacterStateType)enumValues.GetValue(i);

                var moduleState = CreateModuleState(moduleType);
                
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
        
        private CharacterState CreateModuleState(CharacterStateType stateType)
        {
            return _instantiator.Instantiate<CharacterState>(new object[] {stateType});
        }
    }

    public enum CharacterStateType
    {
        Idle,
        Walk,
        Do,
        Pickup
    }
}