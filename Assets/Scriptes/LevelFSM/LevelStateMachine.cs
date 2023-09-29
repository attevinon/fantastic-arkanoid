using System;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class LevelStateMachine
    {
        private Dictionary<Type, BaseLevelState> _states;
        private BaseLevelState _currentState;

        public LevelStateMachine()
        {
            _states = new Dictionary<Type, BaseLevelState>()
            {
                [typeof(LoadingLevelState)] = new LoadingLevelState(this),
                [typeof(GameplayLevelState)] = new GameplayLevelState(this),
            };
        }

        public void EnterIn<TState>() where TState : BaseLevelState
        {
            if(_states.TryGetValue(typeof(TState), out BaseLevelState newState))
            {
                _currentState?.ExitState();
                _currentState = newState;
                newState.EnterState();
            }
        }
    }
}
