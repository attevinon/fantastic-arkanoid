using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid
{
    [RequireComponent(typeof(Text))]
    public class MultiplierView : MonoBehaviour
    {
        [SerializeField] private string _template;
        private Text _combosText;
        private void Awake()
        {
            _combosText = GetComponent<Text>();
        }
        private void OnEnable()
        {
            MultiplierCounter.MultiplierUpdated += OnMultiplierUpdated; 
        }
        private void OnDisable()
        {
            MultiplierCounter.MultiplierUpdated -= OnMultiplierUpdated; 
        }
        public void OnMultiplierUpdated(int multiplier) 
        {
            if(multiplier <= 1)
            {
                HideText(true);
            }
            else
            {
                _combosText.text = string.Format(_template, "Combo", multiplier);
                HideText(false);
            }
        }

        private void HideText(bool hide)
        {
            int targetAlpha = hide ? 0 : 1;
            if (_combosText.color.a == targetAlpha)
                return;

            Color color = _combosText.color;
            color.a = targetAlpha;
            _combosText.color = color;
        }
    }
}
