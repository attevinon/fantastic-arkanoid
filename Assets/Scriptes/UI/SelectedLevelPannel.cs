using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Utilites;

namespace FantasticArkanoid.UI
{
    public class SelectedLevelPannel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _levelInfoContainer;
        [SerializeField] private Text _levelHeader;
        [SerializeField] private Button _playButton;

        private void Start()
        {
            _levelInfoContainer.EnableCanvasGroup(false);
        }

        public void ShowSelectedLevelInfo(bool isLevelOpened)
        {
            _levelInfoContainer.EnableCanvasGroup(true);

            _levelHeader.text = $"Level {LevelIndex.SelctedLevelIndex}";
            _playButton.interactable = isLevelOpened;
        }

        public void OnPlayClicked()
        {
            SceneLoader loader = new SceneLoader();
            loader.LoadScene(Scenes.Game);
        }
    }
}
