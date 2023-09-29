using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public abstract class BaseLevelState
    {
        protected LevelStateMachine StateMachine { get; }
        public BaseLevelState(LevelStateMachine stateMachine) 
        {
            StateMachine = stateMachine;
        }
        public abstract void EnterState();
        public abstract void ExitState();
    }
}
