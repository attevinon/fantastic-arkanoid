using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public abstract class BaseLevelState
    {
        protected LevelStateMachine StateMachine { get; private set; }
        public void SetStateMachine(LevelStateMachine stateMachine)
        {
            if(StateMachine == null)
            {
                StateMachine = stateMachine;
            }
        }
        public abstract void EnterState();
        public abstract void ExitState();
    }
}
