using System;
using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Text _buttonText;
        private Action<bool> _onClicked;
        private int _levelIndex;
        private bool _isOpened;

        public void Initialize(int levelIndex, LevelProgressData levelProgress, LevelsMenu menu)
        {
            _levelIndex = levelIndex;
            _buttonText.text = _levelIndex.ToString();
            _isOpened = levelProgress.IsOpened;

            _onClicked += menu.OnLevelSelected;
        }

        public void OnLevelButtonClicked()
        {
            LevelIndex.SelctedLevelIndex = _levelIndex;
            _onClicked?.Invoke(_isOpened);
        }
    }
}
