using UnityEngine;

namespace FantasticArkanoid
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _bricksParent;
        [SerializeField] private LevelCleaner _levelCleaner;

        private LevelStateMachine _stateMachine;

        private BricksInitializer _bricksInitializer;

        private void Start()
        {
            _stateMachine = new LevelStateMachine();
            _stateMachine.EnterIn<LoadingLevelState>();

            _bricksInitializer = new BricksInitializer();
            Initialize();
        }
        public void Initialize()
        {
            _levelCleaner.CleanLevel();

            LevelStaticData levelData = Resources.Load<LevelStaticData>("Levels/Level_" + LevelIndex.SelctedLevelIndex);

            if (levelData == null)
                return;

            _bricksInitializer.InitializeBricks(levelData, _bricksParent);

            _stateMachine.EnterIn<GameplayLevelState>();
        }
    }
}
