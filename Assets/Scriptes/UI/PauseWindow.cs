using UnityEngine;
using FantasticArkanoid.Utilites;
using System;

namespace FantasticArkanoid.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PauseWindow : MonoBehaviour
    {
        private CanvasGroup _pannel;
        private bool isWindowOpened => _pannel.alpha != 0f;
        private LevelStateMachine _levelStateMachine;

        private void Awake()
        {
            _pannel = GetComponent<CanvasGroup>();
            ShowWindow(false);
        }

        public void Initialize(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void ShowWindow(bool value)
        {
            if (isWindowOpened == value)
                return;

            _pannel.EnableCanvasGroup(value);
        }

        public void OnBackToGameClicked()
        {
            if (!isWindowOpened)
                return;

            ShowWindow(false);
            _levelStateMachine.EnterIn<GameplayLevelState>();
        }

        public void OnBackToLevelsMenuClicked()
        {
            ShowWindow(false);
            _levelStateMachine.EnterIn<LoadingLevelState>();

            //show warning

            SceneLoader sceneLoader = new SceneLoader();
            sceneLoader.LoadScene(Scenes.LevelsMenu);
        }
    }
}
