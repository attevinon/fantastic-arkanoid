using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    public class LevelsMenu : MonoBehaviour
    {
        [SerializeField] private Text _levelHeader;
        [SerializeField] private Button _playButton;
        [SerializeField] private CanvasGroup _levelInfoContainer;
        [SerializeField] private CanvasGroup _noLevelSelectedContainer;

        private void Start()
        {
            EnableCanvasGroup(_levelInfoContainer, false);
            EnableCanvasGroup(_noLevelSelectedContainer, true);
        }
        public void OnLevelSelected(bool isOpened)
        {
            EnableCanvasGroup(_noLevelSelectedContainer, false);
            ShowSelectedLevelInfo(isOpened);
        }

        private void EnableCanvasGroup(CanvasGroup canvasGroup, bool enable)
        {
            canvasGroup.alpha = enable ? 1 : 0;
            canvasGroup.interactable = enable;
        }

        private void ShowSelectedLevelInfo(bool isOpened)
        {
            EnableCanvasGroup(_levelInfoContainer, true);

            _levelHeader.text = $"Level {LevelIndex.SelctedLevelIndex}";
            _playButton.interactable = isOpened;
        }
        public void OnPlayClicked()
        {
            SceneLoader loader = new SceneLoader();
            loader.LoadScene(Scenes.Game);
        }
    }
}
