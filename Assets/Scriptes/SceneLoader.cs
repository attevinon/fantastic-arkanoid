using UnityEngine.SceneManagement;

namespace FantasticArkanoid
{
    public class SceneLoader
    {
        public void LoadScene(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
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
