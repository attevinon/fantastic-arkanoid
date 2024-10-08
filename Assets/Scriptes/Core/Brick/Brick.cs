using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FantasticArkanoid.Scriptable;

namespace FantasticArkanoid
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Brick : BaseBrick
    {
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private SpriteRenderer _spriteRenerer;
        [SerializeField] private UnityEvent _onDied;
        
        private int _lives;
        private int _starterScorePoints;
        private int _scorePointsLeft;
        private event Action<int> _onScorePointsKnockedOut;

        public void Initialize(BreakableBrickData data, Action<int> onScorePointsKnockedOut)
        {
            base.Initialize(data);

            _sprites = new List<Sprite>(data.Sprites);
            _spriteRenerer = GetComponent<SpriteRenderer>();

            _lives = _sprites.Count;
            _spriteRenerer.sprite = _sprites[_lives - 1];

            _scorePointsLeft = _starterScorePoints = data.ScorePoints;
            _onScorePointsKnockedOut += onScorePointsKnockedOut;
        }

        public void OnDamage()
        {
            _lives--;
            if (_lives <= 0)
            {
                _onDied?.Invoke();
                _onScorePointsKnockedOut?.Invoke(_starterScorePoints);
            }
            else
            {
                _spriteRenerer.sprite = _sprites[_lives - 1];
                _onScorePointsKnockedOut?.Invoke(CalculateScorePointsToAdd());
            }
        }

        private int CalculateScorePointsToAdd()
        {
            int points = _scorePointsLeft / ((_lives + 1 ) * _lives + 1);
            return points;
        }
    }
}
