using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FantasticArkanoid.Scriptable;

namespace FantasticArkanoid
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(ParticleSystem))]
    public class Brick : MonoBehaviour
    {
        
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private int _lives;
        [SerializeField] private SpriteRenderer _spriteRenerer;
        //[SerializeField] private int _scorePoints;

        [SerializeField] private UnityEvent _onDied;

        private ParticleSystem _debrisParticles;

#if UNITY_EDITOR
        public BrickData Data; 
#endif
        public void Initialize(BreakableBrickData data)
        {
            //_scorePoints = data.ScorePoints;

            _sprites = new List<Sprite>(data.Sprites);
            _spriteRenerer = GetComponent<SpriteRenderer>();

            _lives = _sprites.Count;
            _spriteRenerer.sprite = _sprites[_lives - 1];

            _debrisParticles = GetComponent<ParticleSystem>();
            ParticleSystem.MainModule mainDebrisParticles = _debrisParticles.main;
            mainDebrisParticles.startColor = new ParticleSystem.MinMaxGradient(data.ParticlesColor);
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

        public void SpawnDebrisParticles()
        {
            _debrisParticles.Play();
        }
        public class ScoreEvent : UnityEvent<int> { } 
    }
}
