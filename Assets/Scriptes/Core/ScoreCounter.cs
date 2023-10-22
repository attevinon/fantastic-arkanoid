using System;
using UnityEngine;
using UnityEngine.Events;
using FantasticArkanoid.Level.Model;

namespace FantasticArkanoid
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int, bool> _scoreUpdated;

        public Action<int> UpdateScore;

        private LevelStateMachine _levelStateMachine;
        private GameSession _gameSession;
        private int _bestScore;

        private void OnEnable()
        {
            UpdateScore += RefillScore;
        }
        private void OnDisable()
        {
            UpdateScore -= RefillScore;
        }

        public void Initialize(LevelStateMachine levelStateMachine,
            GameSession gameSession, int bestScore)
        {
            _levelStateMachine = levelStateMachine;
            _gameSession = gameSession;
            _bestScore = bestScore;
        }

        private void RefillScore(int points)
        {
            if (_levelStateMachine.IsCurrentState<GameplayLevelState>())
            {
                int tmpPoints = points;
                if (points > 0)
                {
                    if(MultiplierCounter.SummaryMultiplier <= 0)
                    {
                        Debug.LogError("SummaryMultiplier is 0 or less!");
                    }

                    tmpPoints *= MultiplierCounter.SummaryMultiplier;
                }

                _gameSession.Data.Score += tmpPoints;
                _scoreUpdated?.Invoke(_gameSession.Data.Score, _gameSession.Data.Score > _bestScore);
            }
        }
    }
}
