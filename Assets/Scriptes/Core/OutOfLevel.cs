using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FantasticArkanoid.Utilites;
using Unity.VisualScripting;

namespace FantasticArkanoid
{
    public class OutOfLevel : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onTheLastBallDied;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
            {
                ball.OnOutOfLevel?.Invoke();
                _onTheLastBallDied?.Invoke();
            }
            
            /*if (collision.gameObject.CompareTag(ConstStrings.Tags.BALL_TAG))
            {
                var ball = collision.gameObject.GetComponent<Ball>();
                if(ball != null)
                {
                    ball.OnOutOfLevel?.Invoke();
                    _onTheLastBallDied?.Invoke();
                }
            }*/
        }
    }
}
