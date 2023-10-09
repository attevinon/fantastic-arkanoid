using UnityEngine;
using FantasticArkanoid.UI;

namespace FantasticArkanoid
{
    public class GameBootstraper : BaseManualInputReader<BootstrapSceneActions>
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        private void Awake()
        {
            _actions = new BootstrapSceneActions();
        }
        private void Start()
        {
            SceneLoader.Instance.LoadingScreen = _loadingScreen;
            _actions.Bootstraper.StartGame.canceled += _ => StartGame();
        }

        private void StartGame()
        {
            SceneLoader.Instance.LoadSceneWithLoading(Scenes.MainMenu); 
        }
    }
}
