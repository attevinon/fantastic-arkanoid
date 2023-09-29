using UnityEngine;

namespace FantasticArkanoid
{
    public class GameplayLevelState : BaseLevelState
    {
        public GameplayLevelState(LevelStateMachine stateMachine) : base(stateMachine) { }

        public override void EnterState()
        {
            Debug.Log("Enter Gameplay");
        }

        public override void ExitState()
        {
            Debug.Log("Exit Gameplay");
        }
    }
}
