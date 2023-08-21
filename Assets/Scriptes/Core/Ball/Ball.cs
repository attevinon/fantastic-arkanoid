using FantasticArcanoid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FantasticArkanoid.Utilites;
using UnityEngine.Events;

namespace FantasticArkanoid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private UnityEvent _onActivate;     
        [SerializeField] private UnityEvent _onDiactivate;

        [SerializeField] public UnityEvent OnOutOfLevel;

        private bool _isBallActive = false;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        private void Start()
        {
            _isBallActive = false;
        }

        public void ActivateBall()
        {
            if (!_isBallActive)
            {
                _isBallActive = true;
                transform.SetParent(null);

                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                _rigidbody.velocity = Vector2.up * _speed;

                _onActivate?.Invoke();
            }
        }

        // SetBallUnactive()

        //вынести в отедельный компонент?
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(ConstStrings.Tags.PADDLE_TAG)) return;

            float x = HitFactor(this.transform.position,
                collision.transform.position,
                collision.collider.bounds.size.x);

            var direction = new Vector2(x, 1).normalized;
            _rigidbody.velocity = direction * _speed;
        }

        private float HitFactor(Vector2 ballPosition, Vector2 paddlePosition, float paddleWidth)
        {
            return (ballPosition.x - paddlePosition.x) / paddleWidth;
        }

        public void ResetBall()
        {
            _isBallActive = false;
        }
    }
}
