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
        [SerializeField] private int _lives;
        [SerializeField] private SpriteRenderer _spriteRenerer;
        //[SerializeField] private int _scorePoints;

        [SerializeField] private UnityEvent _onDied;

        public void Initialize(BreakableBrickData data)
        {
            base.Initialize(data);

            //_scorePoints = data.ScorePoints;
            _sprites = new List<Sprite>(data.Sprites);
            _spriteRenerer = GetComponent<SpriteRenderer>();

            _lives = _sprites.Count;
            _spriteRenerer.sprite = _sprites[_lives - 1];
        }

        public void OnDamage()
        {
            _lives--;
            if (_lives <= 0)
            {
                _onDied?.Invoke();
            }
            else
            {
                _spriteRenerer.sprite = _sprites[_lives - 1];
            }
        }

        //public class ScoreEvent : UnityEvent<int> { } 
    }
}
