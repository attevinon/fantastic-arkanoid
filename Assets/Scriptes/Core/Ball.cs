using FantasticArcanoid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;
        private const string PADDLE_TAG = "Paddle"; 

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rigidbody.velocity = Vector2.up * _speed;
        }

        //вынести в отедельный компонент?
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(PADDLE_TAG)) return;

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
    }
}
