using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    [RequireComponent(typeof(Text))]
    public class PulsatingText : MonoBehaviour
    {
        [SerializeField] private int _minFontSize;
        [SerializeField] private int _maxFontSize;
        [SerializeField, Range(0, 1)] private float _smoothing = 0.1f;

        private int _currentFontSize => _text.fontSize;
        private bool _isToMinSize = true;
        private Text _text;

        protected void OnValidate()
        {
            _text = GetComponent<Text>();

            if (_maxFontSize < _minFontSize)
            {
                _maxFontSize = _minFontSize + 1;
            }

            if(_minFontSize > _maxFontSize)
            {
                _minFontSize = _maxFontSize - 1;
            }

            _text.fontSize = _maxFontSize;
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            if(!_isToMinSize)
            {
                _text.fontSize = Mathf.CeilToInt(GetNewFontSize());

                if (_maxFontSize - _currentFontSize <= 1)
                    _isToMinSize = true;
            }
            else if (_isToMinSize)
            {
                _text.fontSize = Mathf.FloorToInt(GetNewFontSize());

                if (_currentFontSize - _minFontSize <= 1)
                    _isToMinSize = false;
            }
        }

        private float GetNewFontSize()
        {
            return Mathf.Lerp(_currentFontSize, _isToMinSize ? _minFontSize : _maxFontSize, _smoothing);
        }
    }
}
