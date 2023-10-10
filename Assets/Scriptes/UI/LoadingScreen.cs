using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    [RequireComponent(typeof(Canvas))]
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField, Min(0)] private float _timeToFade = 0.5f;
        [SerializeField, Min(0)] private float _timeToStayEnabled = 1f;

        public static LoadingScreen Instance { get; private set; }
        public Action OnShown { private get; set; }

        private Canvas _canvas;
        private float _timePassedWhileEnabled;
        private bool _targetEnable;

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

            enabled = false;
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
            _image.color = GetColorForAlpha(_image.color, 0f);
            _image.raycastTarget = false;
        }

        private void Update()
        {
            _timePassedWhileEnabled += Time.unscaledDeltaTime;
        }

        public void Enable(bool enable)
        {
            if (_targetEnable == enable)
                return;

            _targetEnable = enable;

            if (enable)
            {
                _timePassedWhileEnabled = 0f;
                _canvas.enabled = true;
                _image.raycastTarget = true;
            }

            enabled = true;
            StartCoroutine(StartTransition(enable));
        }

        private IEnumerator StartTransition(bool enable)
        {
            if(!enable && _timePassedWhileEnabled < _timeToStayEnabled)
            {
                yield return new WaitForSecondsRealtime(_timeToStayEnabled - _timePassedWhileEnabled);
            }

            yield return SmoothTransition(enable ? 1f : 0f);

            enabled = enable;
            _image.raycastTarget = enable;
            OnShown?.Invoke();
            OnShown = null;
        }

        private IEnumerator SmoothTransition(float targetAlpha)
        {
            float timeHasPassed = 0f;
            var startAlpha = _image.color.a;

            while (timeHasPassed < _timeToFade)
            {
                timeHasPassed += Time.unscaledDeltaTime;

                float progress = timeHasPassed / _timeToFade;

                float tmpAlpha = Mathf.Lerp(startAlpha, targetAlpha, progress);
                _image.color = GetColorForAlpha(_image.color, tmpAlpha);

                yield return null;
            }
        }

        private Color GetColorForAlpha(Color color, float targetAlpha)
        {
            Color newColor = color;
            newColor.a = targetAlpha;
            return newColor;
        }
    }
}
