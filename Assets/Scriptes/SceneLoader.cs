using UnityEngine;
using UnityEngine.SceneManagement;
using FantasticArkanoid.UI;

namespace FantasticArkanoid
{
    public class SceneLoader
    {
        private static SceneLoader _instance;
        public static SceneLoader Instance
        { 
            get
            {
                _instance ??= new SceneLoader();
                return _instance;
            }
        }

        private LoadingScreen _loadingScreen;
        public LoadingScreen LoadingScreen 
        {
            get => _loadingScreen;
            set
            {
                _loadingScreen ??= value;
            }
        }

        private SceneLoader() { }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadScene(Scenes sceneName)
        {
            SceneManager.LoadScene(sceneName.ToString());
        }

        public void LoadSceneWithLoading(Scenes sceneName)
        {
#if UNITY_EDITOR
            if(LoadingScreen == null)
            {
                LoadScene(sceneName);
                return;
            }
#endif
            var scene = SceneManager.LoadSceneAsync(sceneName.ToString());
            scene.allowSceneActivation = false;

            LoadingScreen.OnShown = () => scene.allowSceneActivation = true;
            scene.completed += OnSceneCompleted;

            LoadingScreen.Enable(true);
        }

        private void OnSceneCompleted(AsyncOperation asyncOperation)
        {
            LoadingScreen.Enable(false);
            asyncOperation.completed -= OnSceneCompleted;
        }
    }

    public enum Scenes
    {
        BootstrapScene,
        MainMenu,
        LevelsMenu,
        Game,
    }
}
