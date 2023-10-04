using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace FantasticArkanoid
{
    public class GameplayUIInputReader : MonoBehaviour
    {
        [SerializeField] private UnityEvent _pauseGame;
        private GameplayUIActions _actions;

        private void Awake()
        {
            _actions = new GameplayUIActions();
        }

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }
        private void Start()
        {
            _actions.GameplayUIMap.Pause.canceled += _ => _pauseGame?.Invoke();
        }

    }
}
