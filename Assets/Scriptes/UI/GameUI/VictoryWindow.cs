using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class VictoryWindow : BaseWindow
    {
        [SerializeField] private Text YourScoreText;
        [SerializeField] private Text BestScoreText;

        public void Initialize(LevelStateMachine levelStateMachine,
            IReadonlyGameResult gameResult, IReadonlyBestResults bestResults)
        {
            base.Initialize(levelStateMachine);

            YourScoreText.text = gameResult.Score.ToString();
            BestScoreText.text = bestResults.BestScore.ToString();
            BestScoreText.color = gameResult.IsNewBestScore ? Color.red : BestScoreText.color;
        }
        public void OnNextLevelCLicked()
        {
            LevelIndex.SelctedLevelIndex++;
            SceneLoader.Instance.RestartScene();
        }
    }
}
