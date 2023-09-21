using UnityEngine;

namespace FantasticArkanoid
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _bricksParent;
        [SerializeField] private LevelCleaner _levelCleaner;

        private BricksInitializer _bricksInitializer = new BricksInitializer();

        private void Start()
        {
            Initialize();
        }
        public void Initialize()
        {
            _levelCleaner.CleanLevel();

            LevelStaticData levelData = Resources.Load<LevelStaticData>("Levels/Level_" + LevelIndex.SelctedLevelIndex);

            if (levelData == null)
                return;

            _bricksInitializer.InitializeBricks(levelData, _bricksParent);
        }
    }
}
