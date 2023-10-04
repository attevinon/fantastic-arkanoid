using UnityEngine;
using FantasticArkanoid.Utilites;
using System;

namespace FantasticArkanoid.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PauseWindow : MonoBehaviour
    {
        private CanvasGroup _pannel;
        public Action OnBackToGame;
        private bool isWindowOpened;

        private void Awake()
        {
            _pannel = GetComponent<CanvasGroup>();
            isWindowOpened = false;
        }

        public void ShowWindow(bool value)
        {
            if (isWindowOpened == value)
                return;

            _pannel.EnableCanvasGroup(value);
            isWindowOpened = value;
        }

        public void OnBackToGameClicked()
        {
            if (!isWindowOpened)
                return;

            OnBackToGame?.Invoke();
        }
    }
}
