using UnityEngine;

namespace FantasticArkanoid
{
    public class LoadingLevelState : BaseLevelState
    {
        public LoadingLevelState(LevelStateMachine stateMachine) : base(stateMachine) { }

        public override void EnterState()
        {
            Debug.Log("Enter Loading");
            //show loading pannel
        }

        public override void ExitState()
        {
            Debug.Log("Exit Loading");
        }
    }
}
