using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArcanoid.Paddle
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private float _direction;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction * _speed, _rigidbody.velocity.y);
        }

        public void SetDirection(float directionX)
        {
            _direction = directionX;
        }
    }
}
