using UnityEngine;
using UnityEngine.Events;
using FantasticArkanoid.Level.Model;

namespace FantasticArkanoid
{
    public class TimeCounter : MonoBehaviour
    {
        [SerializeField] private UnityEvent _timeUpdated;
        private GameSession _gameSession;
        private float _oneSec;
        private void Awake()
        {
            this.enabled = false;
        }
        public void Initialize(GameSession gameSession)
        {
            _gameSession = gameSession;
            _oneSec = 0f;
            this.enabled = true;
        }

        private void Update()
        {
            _oneSec += Time.deltaTime;

            if(_oneSec >= 1)
            {
                _oneSec -= 1;
                _gameSession.Data.Time++;
                _timeUpdated?.Invoke();
            }
        }
    }
}
