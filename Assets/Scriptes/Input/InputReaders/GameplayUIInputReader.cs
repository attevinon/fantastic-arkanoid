using UnityEngine;
using UnityEngine.Events;

namespace FantasticArkanoid
{
    public class GameplayUIInputReader : BaseManualInputReader<GameplayUIActions>
    {
        [SerializeField] private UnityEvent _pauseGame;

        private void Awake()
        {
            _actions = new GameplayUIActions();
        }

        private void Start()
        {
            _actions.GameplayUIMap.Pause.canceled += _ => _pauseGame?.Invoke();
        }

    }
}
