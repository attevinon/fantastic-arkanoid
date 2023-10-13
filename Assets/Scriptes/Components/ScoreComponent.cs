using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FantasticArkanoid
{
    public class ScoreComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> _onScoreUpdated;
        private int _score;

        public Action<int> UpdateScore;

        private void OnEnable()
        {
            UpdateScore += RefillScore;
        }
        private void OnDisable()
        {
            UpdateScore -= RefillScore;
        }
        public void RefillScore(int points)
        {
            //check gamestate?
            _score += points;
            _onScoreUpdated?.Invoke(_score);
        }
    }
}
