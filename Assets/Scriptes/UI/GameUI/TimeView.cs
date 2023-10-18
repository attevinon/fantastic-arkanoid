using FantasticArkanoid.Utilites;
using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid
{
    [RequireComponent(typeof(Text))]
    public class TimeView : MonoBehaviour
    {
        [SerializeField] private string _template;
        private Text _timeText;
        private float _seconds;
        private void Awake()
        {
            _timeText = GetComponent<Text>();
        }

        public void OnTimeUpdated()
        {
            _seconds++;
            _timeText.text = string.Format(_template, "Time", TimeFormatter.ToMmSs(_seconds));
        }
    }
}
