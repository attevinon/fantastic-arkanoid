using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    [RequireComponent(typeof(Text))]
    public class ScoreView : MonoBehaviour
    {
        private Text _scorePointsText;
        private void Awake()
        {
            _scorePointsText = GetComponent<Text>();
        }
        public void OnScoreUpdated(int score, bool isRecord)
        {
            _scorePointsText.text = $"Score: {score}";
            _scorePointsText.color = isRecord ? Color.yellow : Color.white;
        }
    }
}
