using UnityEngine;
using UnityEngine.InputSystem;

namespace FantasticArkanoid
{
    public class GameplayLevelState : BaseLevelState
    {
        private PlayerInput _input;
        public GameplayLevelState(PlayerInput input)
        {
            _input = input;
        }
        public override void EnterState()
        {
            _input.enabled = true;
            Debug.Log("Enter Gameplay");
        }

        public override void ExitState()
        {
            _input.enabled = false;
            Debug.Log("Exit Gameplay");
        }
    }
}
