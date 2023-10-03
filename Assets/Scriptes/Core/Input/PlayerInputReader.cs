using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using FantasticArkanoid.Components;

namespace FantasticArkanoid
{
    public class PlayerInputReader : MonoBehaviour
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
        }

        public void OnActivateBall(InputAction.CallbackContext callback)
        {
            if (callback.canceled)
            {
                if (callback.control.path.Equals("/Mouse/leftButton")
                    && EventSystem.current.IsPointerOverGameObject())
                {
                        return;
                }

                var ball = _parent.GetComponentInChildren<Ball>();

                if(ball != null)
                {
                    ball.ActivateBall();
                }
            }
        }
    }
}
