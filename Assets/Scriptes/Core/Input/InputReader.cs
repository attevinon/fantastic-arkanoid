using FantasticArkanoid;
using FantasticArkanoid.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

namespace FantasticArkanoid
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;

        private MovementComponent _movement;
        private void Awake()
        {
            _movement = GetComponent<MovementComponent>();
        }

        public void OnAxisInput(InputAction.CallbackContext callback)
        {
            var direction = callback.ReadValue<float>();
            _movement.SetDirection(direction);

            /*var gos = FindObjectsOfType<MovementComponent>();
            if(gos != null)
            {
                var direction = callback.ReadValue<float>();
                foreach (var go in gos)
                {
                    go.SetDirection(direction);
                }
            }*/

        }

        public void OnActivateBall(InputAction.CallbackContext callback)
        {
            if (callback.canceled)
            {
                var ball = _parent.GetComponentInChildren<Ball>();

                if(ball != null)
                {
                    ball.ActivateBall();
                }
            }
        }
    }
}
