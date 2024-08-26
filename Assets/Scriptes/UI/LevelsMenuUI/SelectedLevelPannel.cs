using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Utilites;
using FantasticArkanoid.Level.ModelAbstractions;
using FantasticArkanoid.Level.Model;

namespace FantasticArkanoid.UI
{
    public class SelectedLevelPannel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _levelInfoContainer;
        [SerializeField] private Text _levelHeader;
        [SerializeField] private Text _bestScoreText;
        [SerializeField] private Text _bestTimeText;
        [SerializeField] private Text _bestComboText;
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
                if (levelProgress.BestResults != null)
                {
                    _bestScoreText.text = levelProgress.BestResults.BestScore.ToString();
                    _bestTimeText.text = TimeFormatter.ToMmSs(levelProgress.BestResults.BestTime);
                    _bestComboText.text = levelProgress.BestResults.BestCombo > 1 ?
                        levelProgress.BestResults.BestCombo.ToString() : "-";
                }
                else
                {
                    _bestScoreText.text = "-";
                    _bestTimeText.text = "-";
                    _bestComboText.text = "-";
                }

            }
        }

        public void OnPlayClicked()
        {
            SceneLoader.Instance.LoadSceneWithLoading(Scenes.Game);
        }
    }
}
