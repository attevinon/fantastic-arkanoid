using UnityEngine;
using FantasticArkanoid.Utilites;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class LevelsMenu : MonoBehaviour
    {
        [SerializeField] private SelectedLevelPannel _selectedLevelPannel;
        [SerializeField] private CanvasGroup _noLevelSelectedPannel;

        private void Start()
        {
            _noLevelSelectedPannel.EnableCanvasGroup(true);
        }
        public void OnLevelSelected(IReadonlyLevelProgress levelProgress)
        {
            _noLevelSelectedPannel.EnableCanvasGroup(false);
            _selectedLevelPannel.ShowSelectedLevelInfo(levelProgress);
        }
    }
}
