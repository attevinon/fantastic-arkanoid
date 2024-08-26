using System;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class LevelStateMachine
    {
        private Dictionary<Type, BaseLevelState> _states;
        private BaseLevelState _currentState;

        public LevelStateMachine(BaseLevelState[] states)
        {
            _states = new Dictionary<Type, BaseLevelState>();
            foreach (var state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }

        public void EnterIn<TState>() where TState : BaseLevelState
        {
            if(_states.TryGetValue(typeof(TState), out BaseLevelState newState))
            {
                if (IsCurrentState<TState>())
                    return;

                _currentState?.ExitState();
                _currentState = newState;
                newState.EnterState();
            }
        }

        public bool IsCurrentState<TState>() where TState : BaseLevelState
        {
            return typeof(TState) == _currentState?.GetType();
        }
    }
}
