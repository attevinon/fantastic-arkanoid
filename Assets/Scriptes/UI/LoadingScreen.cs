using System.Collections;
using UnityEngine;

namespace FantasticArkanoid.UI
{
    [RequireComponent(typeof(Canvas))]
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _pannel;
        [SerializeField, Range(0, 1)] private float _smoothing = 0.02f;
        public static LoadingScreen Instance { get; private set; }

        private Canvas _canvas;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }

            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
        }
        public void Enable(bool enable)
        {
            if (_canvas.enabled == enable)
                return;

            SmoothTransition(enable ? 1f : 0f);
            _canvas.enabled = enable;
        }

        private void SmoothTransition(float targetAlpha)
        {
            while (_pannel.alpha != targetAlpha && !(_pannel.alpha < 0))
            {
                _pannel.alpha = Mathf.Lerp(_pannel.alpha, targetAlpha, _smoothing);

                if(Mathf.Abs(_pannel.alpha - targetAlpha) <= 0.01f)
                {
                    _pannel.alpha = targetAlpha;
                }
            }
        }
    }
}
