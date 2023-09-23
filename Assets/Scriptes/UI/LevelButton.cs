using System;
using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Text _buttonText;
        private int _levelIndex;
        private Action<bool> _onClicked;
        public void Initialize(int levelIndex, LevelsMenu menu)
        {
            _levelIndex = levelIndex;
            _buttonText.text = _levelIndex.ToString();
            _onClicked += menu.OnLevelSelected;
        }

        public void OnLevelButtonClicked()
        {
            LevelIndex.SelctedLevelIndex = _levelIndex;
            _onClicked?.Invoke(true);
        }
    }
}
