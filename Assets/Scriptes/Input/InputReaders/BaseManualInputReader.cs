using UnityEngine;
using UnityEngine.InputSystem;

namespace FantasticArkanoid
{
    public class BaseManualInputReader<TActions> : MonoBehaviour where TActions : IInputActionCollection2
    {
        protected TActions _actions;

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }
    }
}
