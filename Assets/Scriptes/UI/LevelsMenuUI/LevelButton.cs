using System;
using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Text _buttonText;
        private Action<IReadonlyLevelProgress> _onClicked;
        private int _levelIndex;
        private IReadonlyLevelProgress _levelProgress;

        public void Initialize(int levelIndex, IReadonlyLevelProgress levelProgress,
            Action<IReadonlyLevelProgress> onClicked)
        {
            _levelIndex = levelIndex;
            _buttonText.text = _levelIndex.ToString();
            _levelProgress = levelProgress;

            _onClicked += onClicked;
        }

        public void OnLevelButtonClicked()
        {
            LevelIndex.SelctedLevelIndex = _levelIndex;
            _onClicked?.Invoke(_levelProgress);
        }
    }
}
