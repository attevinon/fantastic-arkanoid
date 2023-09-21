using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Text _buttonText;
        private int _levelIndex;
        public void Initialize(int levelIndex)
        {
            _levelIndex = levelIndex;
            _buttonText.text = _levelIndex.ToString();
        }

        public void OnLevelButtonClicked()
        {
            LevelIndex.SelctedLevelIndex = _levelIndex;

            SceneLoader loader = new SceneLoader();
            loader.LoadScene(Scenes.Game);
        }
    }
}
