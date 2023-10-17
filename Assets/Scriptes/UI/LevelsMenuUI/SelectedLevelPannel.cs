using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Utilites;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class SelectedLevelPannel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _levelInfoContainer;
        [SerializeField] private Text _levelHeader;
        [SerializeField] private Text _bestScoreText;
        [SerializeField] private Button _playButton;

        private void Start()
        {
            _levelInfoContainer.EnableCanvasGroup(false);
        }

        public void ShowSelectedLevelInfo(IReadonlyLevelProgress levelProgress)
        {
            _levelInfoContainer.EnableCanvasGroup(true);
            _levelHeader.text = $"Level {LevelIndex.SelctedLevelIndex}";
            _playButton.interactable = levelProgress.IsOpened;

            if (levelProgress.IsOpened)
            {
                bool isBestResultsNull = levelProgress.BestResults != null;
                _bestScoreText.text = isBestResultsNull ? levelProgress.BestResults.BestScore.ToString() : "-";
            }
        }

        public void OnPlayClicked()
        {
            SceneLoader.Instance.LoadSceneWithLoading(Scenes.Game);
        }
    }
}
