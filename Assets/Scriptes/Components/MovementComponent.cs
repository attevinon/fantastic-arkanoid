using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private SpriteRenderer _paddleSprite;
        [SerializeField] private float _offset = 0.1f;
        private static float _movementSpeed = 5;
        private float _direction;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            var x = _rigidbody.position.x + _direction * _movementSpeed * Time.deltaTime;
            var halfOfPaddle = _paddleSprite.size.x / 2;

            x = Mathf.Clamp(x,
                _leftBorder.position.x + halfOfPaddle + _offset,
                _rightBorder.position.x - halfOfPaddle - _offset);

            _rigidbody.MovePosition(new Vector2(x, _rigidbody.position.y));
        }

        public void SetDirection(float directionX)
        {
            _direction = directionX;
        }
    }
}
