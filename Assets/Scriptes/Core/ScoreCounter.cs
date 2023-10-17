using System;
using UnityEngine;
using UnityEngine.Events;
using FantasticArkanoid.Level.Model;

namespace FantasticArkanoid
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> _onScoreUpdated;

        public Action<int> UpdateScore;

        private LevelStateMachine _levelStateMachine;
        private GameSession _gameSession;

        private void OnEnable()
        {
            UpdateScore += RefillScore;
        }
        private void OnDisable()
        {
            UpdateScore -= RefillScore;
        }

        public void Initialize(LevelStateMachine levelStateMachine, GameSession gameSession)
        {
            _levelStateMachine = levelStateMachine;
            _gameSession = gameSession;
        }

        private void RefillScore(int points)
        {
            if (_levelStateMachine.IsCurrentState<GameplayLevelState>())
            {
                _gameSession.Data.Score += points;
                _onScoreUpdated?.Invoke(_gameSession.Data.Score);
            }
        }
    }
}
