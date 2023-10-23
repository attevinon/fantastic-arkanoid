using UnityEngine;
using UnityEngine.Events;
using FantasticArkanoid.Utilites;

namespace FantasticArkanoid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        const float MIN_FACTOR = 0.1f;
        [SerializeField] private float _speed;

        [SerializeField] private UnityEvent _onActivate;     
        [SerializeField] private UnityEvent _onDiactivate;
        [SerializeField] private UnityEvent _onBrickCollision;
        [SerializeField] private UnityEvent _onPaddleCollision;

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
        private void FixedUpdate()
        {
            LimitVelocity();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Brick brick))
            {
                _onBrickCollision?.Invoke();
                brick.OnDamage();
            }

            if (collision.gameObject.CompareTag(ConstStrings.Tags.PADDLE_TAG))
            {
                _onPaddleCollision?.Invoke();

                float x = CalculatePaddleHitFactor(this.transform.position,
                    collision.transform.position,
                    collision.collider.bounds.size.x);

                var direction = new Vector2(x, 1).normalized;
                _rigidbody.velocity = direction * _speed;
                return;
            }

            Vector2 newDirection = _rigidbody.velocity.normalized;

            if (Mathf.Abs(_rigidbody.velocity.x) < MIN_FACTOR)
            {
                newDirection.x = ToMinHitFactor(newDirection.x);
            }
            if (Mathf.Abs(_rigidbody.velocity.y) < MIN_FACTOR)
            {
                newDirection.y = ToMinHitFactor(newDirection.y);
            }

            _rigidbody.velocity = newDirection * _speed;
        }
        private void LimitVelocity()
        {
            if(_rigidbody.velocity.magnitude > _speed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
            }
        }

        private float ToMinHitFactor(float velocity)
        {
            int direction = velocity > 0 ? 1 : -1;
            if(velocity == 0)
            {
                direction = Random.Range(0, 2) == 0 ? 1 : -1;
            }
            return direction * MIN_FACTOR;
        }
        private float CalculatePaddleHitFactor(Vector2 ballPosition,
            Vector2 paddlePosition, float paddleWidth)
        {
            return (ballPosition.x - paddlePosition.x) / paddleWidth;
        }

        public void ResetBall()
        {
            _isBallActive = false;
        }
    }
}
