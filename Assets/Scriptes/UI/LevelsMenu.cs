using UnityEngine;
using FantasticArkanoid.Utilites;

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
        public void OnLevelSelected(bool isLevelOpened)
        {
            _noLevelSelectedPannel.enabled = false;
            _selectedLevelPannel.ShowSelectedLevelInfo(isLevelOpened);
        }
    }
}
