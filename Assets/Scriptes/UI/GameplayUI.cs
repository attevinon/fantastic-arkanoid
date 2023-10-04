using UnityEngine;

namespace FantasticArkanoid.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private PauseWindow _pauseWindow;
        private LevelStateMachine _levelStateMachine;

        public void Initialize(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
            _pauseWindow.Initialize(levelStateMachine);
        }
        public void PauseGame()
        {
            _levelStateMachine.EnterIn<PauseLevelState>();
            _pauseWindow.ShowWindow(true);
        }
    }
}
