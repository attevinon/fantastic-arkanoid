using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Level.ModelAbstractions;
using FantasticArkanoid.Utilites;

namespace FantasticArkanoid.UI
{
    public class VictoryWindow : BaseWindow
    {
        [Header("Score")]
        [SerializeField] private Text YourScoreText;
        [SerializeField] private Text BestScoreText;

        [Header("Time")]
        [SerializeField] private Text YourTimeText;
        [SerializeField] private Text BestTimeText;

        public void Initialize(LevelStateMachine levelStateMachine,
            IReadonlyGameResult gameResult, IReadonlyBestResults bestResults)
        {
            base.Initialize(levelStateMachine);

            YourScoreText.text = gameResult.Score.ToString();
            BestScoreText.text = bestResults.BestScore.ToString();
            BestScoreText.color = gameResult.IsNewBestScore ? Color.red : Color.black;

            YourTimeText.text = TimeFormatter.ToMmSs(gameResult.Time);
            BestTimeText.text = TimeFormatter.ToMmSs(bestResults.BestTime);
            BestTimeText.color = gameResult.IsNewBestTime ? Color.red : Color.black;

        }
        public void OnNextLevelCLicked()
        {
            LevelIndex.SelctedLevelIndex++;
            SceneLoader.Instance.RestartScene();
        }
    }
}
