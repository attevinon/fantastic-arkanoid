using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

namespace FantasticArcanoid
{
    public class PaddleInputReader : MonoBehaviour
    {
        [SerializeField] private Paddle _paddle;
        public void OnAxisInput(InputAction.CallbackContext callback)
        {
            var direction = callback.ReadValue<float>();
            _paddle.SetDirection(direction);
        }
    }
}
