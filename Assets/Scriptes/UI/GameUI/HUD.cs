using UnityEngine;
using UnityEngine.UI;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private PauseWindow _pauseWindow;

        public void Initialize(LevelStateMachine levelStateMachine,
            IReadonlyGameSessionData gameSessionData, IReadonlyBestResults bestResults)
        {
            _pauseWindow.Initialize(levelStateMachine, gameSessionData, bestResults);
        }
        public void PauseGame()
        {
            _pauseWindow.ShowWindow(true);
        }
    }
}
