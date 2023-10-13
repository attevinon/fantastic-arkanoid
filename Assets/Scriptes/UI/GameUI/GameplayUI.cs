using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private Text _scorePointsText;
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

        public void UpdateScore(int score)
        {
            _scorePointsText.text = score.ToString();
        }
    }
}
