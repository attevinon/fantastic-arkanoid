using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private Text _scorePointsText;
        [SerializeField] private PauseWindow _pauseWindow;

        public void Initialize(LevelStateMachine levelStateMachine,
            IReadonlyGameSessionData gameSessionData, IReadonlyBestResults bestResults)
        {
            _pauseWindow.Initialize(levelStateMachine, gameSessionData, bestResults);
        }
        public void PauseGame()
        {
            _pauseWindow.ShowWindow(true);
        }

        public void UpdateScore(int score)
        {
            _scorePointsText.text = score.ToString();
        }
    }
}
