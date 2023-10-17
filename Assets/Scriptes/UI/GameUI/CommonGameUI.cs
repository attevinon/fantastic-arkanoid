using UnityEngine;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class CommonGameUI : MonoBehaviour
    {
        [SerializeField] private GameplayUI _gameplayUI;
        [SerializeField] private VictoryWindow _victoryWindow;
        //[SerializeField] private GameObject _warningWindow;

        private LevelStateMachine _levelStateMachine;

        public void Initialize(LevelStateMachine levelStateMachine,
            IReadonlyGameSessionData gameSessionData, IReadonlyBestResults bestResults)
        {
            _levelStateMachine = levelStateMachine;
            _gameplayUI.Initialize(levelStateMachine, gameSessionData, bestResults);
        }

        public void ShowWinResult(IReadonlyGameResult gameResult, IReadonlyBestResults bestResults)
        {
            _victoryWindow.Initialize(_levelStateMachine, gameResult, bestResults);
            _victoryWindow.ShowWindow(true);
        }

        public void RestartLevel(bool showWarning)
        {
            SceneLoader.Instance.RestartScene();
        }

        public void BackToLevelsMenu(bool showWarning)
        {
            SceneLoader.Instance.LoadSceneWithLoading(Scenes.LevelsMenu);
        }
    }
}
