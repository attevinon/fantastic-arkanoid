using UnityEngine;
using FantasticArkanoid.Utilites;

namespace FantasticArkanoid.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BaseWindow : MonoBehaviour
    {
        protected CanvasGroup _pannel;
        protected LevelStateMachine _levelStateMachine;
        protected bool isWindowOpened => _pannel.alpha != 0f;

        private void Awake()
        {
            _pannel = GetComponent<CanvasGroup>();
        }

        public void Initialize(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
            ShowWindow(false);
        }

        public virtual void ShowWindow(bool value)
        {
            if (isWindowOpened == value)
                return;

            _pannel.EnableCanvasGroup(value);

            if (value)
            {
                _levelStateMachine.EnterIn<PauseLevelState>();
            }
        }
    }
}
