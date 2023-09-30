using FantasticArkanoid.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FantasticArkanoid
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerInput  _input;
        [SerializeField] private Transform _bricksParent;
        [SerializeField] private LevelCleaner _levelCleaner;

        private LevelStateMachine _levelStateMachine;
        private BricksInitializer _bricksInitializer;

        private void Start()
        {
            _levelStateMachine = SetLevelStateMachine();
            _levelStateMachine.EnterIn<LoadingLevelState>();

            _bricksInitializer = new BricksInitializer();
            Initialize();
        }
        private LevelStateMachine SetLevelStateMachine()
        {
            BaseLevelState[] states = new BaseLevelState[]
            {
                new LoadingLevelState(),
                new GameplayLevelState(_input)
            };

            var levelStateMachine = new LevelStateMachine(states);

            foreach (var state in states)
            {
                state.SetStateMachine(_levelStateMachine);
            }

            return levelStateMachine;
        }
        public void Initialize()
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

            _bricksInitializer.InitializeBricks(levelData, _bricksParent);

            _levelStateMachine.EnterIn<GameplayLevelState>();
        }
    }
}
