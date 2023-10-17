using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class PauseWindow : BaseWindow
    {
        [SerializeField] private Text _scorePoitsText;
        [SerializeField] private Text _bestScorePoitsText;

        private IReadonlyGameSessionData _gameSessionData;
        public void Initialize(LevelStateMachine levelStateMachine,
            IReadonlyGameSessionData gameSessionData, IReadonlyBestResults bestResults)
        {
            _gameSessionData = gameSessionData;
            base.Initialize(levelStateMachine);

            if(bestResults != null)
            {
                _bestScorePoitsText.text = bestResults.BestScore.ToString();
            }
            else
            {
                _bestScorePoitsText.text = "-";
            }

        }

        public override void ShowWindow(bool value)
        {
            if (value)
            {
                _scorePoitsText.text = _gameSessionData.Score.ToString();
            }

            base.ShowWindow(value);
        }
        public void OnBackToGameClicked()
        {
            if (!isWindowOpened)
                return;

            ShowWindow(false);
            _levelStateMachine.EnterIn<GameplayLevelState>();
        }
    }
}
