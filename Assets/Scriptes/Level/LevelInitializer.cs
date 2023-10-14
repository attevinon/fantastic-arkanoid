using UnityEngine;
using UnityEngine.InputSystem;
using FantasticArkanoid.UI;

namespace FantasticArkanoid
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private LevelCleaner _levelCleaner;
        [SerializeField] private PlayerInput  _input;
        [SerializeField] private Transform _bricksParent;
        [SerializeField] private ScoreCounter _scoreComponent;
        [SerializeField] private GameplayUI _gameplayUI;
       
        private LevelStateMachine _levelStateMachine;
        private BricksInitializer _bricksInitializer;

        private void Start()
        {
            _levelStateMachine = SetLevelStateMachine();
            _levelStateMachine.EnterIn<PauseLevelState>();

            _gameplayUI.Initialize(_levelStateMachine);

            _bricksInitializer = new BricksInitializer();

            InitializeLevel();
        }
        private LevelStateMachine SetLevelStateMachine()
        {
            BaseLevelState[] states = new BaseLevelState[]
            {
                new PauseLevelState(),
                new GameplayLevelState(_input),
            };

            var levelStateMachine = new LevelStateMachine(states);

            foreach (var state in states)
            {
                state.SetStateMachine(_levelStateMachine);
            }

            return levelStateMachine;
        }
        public void InitializeLevel()
        {
            _levelCleaner.CleanLevel();

            LevelStaticData levelData = Resources.Load<LevelStaticData>("Levels/Level_" + LevelIndex.SelctedLevelIndex);

            if (levelData == null)
            {
#if UNITY_EDITOR
                levelData = Resources.Load<LevelStaticData>("Levels/Level_" + 1);
#else
                return;
#endif
            }

            _bricksInitializer.InitializeBricks(levelData, _bricksParent, _scoreComponent);

            _levelStateMachine.EnterIn<GameplayLevelState>();
        }
    }
}
