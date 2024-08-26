using System;
using UnityEngine;
using UnityEngine.InputSystem;
using FantasticArkanoid.UI;
using FantasticArkanoid.Level.Model;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private LevelCleaner _levelCleaner;
        [SerializeField] private PlayerInput  _input;
        [SerializeField] private Transform _bricksParent;

        [Header("Counters")]
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TimeCounter _timeCounter;

        [Header("UI")]
        [SerializeField] private CommonGameUI _commonGameUI;
       
        private LevelStateMachine _levelStateMachine;
        private BricksInitializer _bricksInitializer;

        private void Start()
        {
            _levelStateMachine = SetLevelStateMachine();
            _levelStateMachine.EnterIn<PauseLevelState>();

#if UNITY_EDITOR
            if(LevelIndex.SelctedLevelIndex == 0)
            {
                LevelIndex.SelctedLevelIndex = 1;
            }
#endif
            IReadonlyBestResults bestResults = GetBestResults();
            GameSession gameSession = new GameSession();
            
            _timeCounter.Initialize(gameSession);
            _scoreCounter.Initialize(_levelStateMachine, gameSession, bestResults != null ? bestResults.BestScore : 0);
            _commonGameUI.Initialize(_levelStateMachine, gameSession.Data, bestResults);
            _ = new GameResultHandler(_levelStateMachine, gameSession.Data, bestResults, _commonGameUI.ShowWinResult);

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

        private IReadonlyBestResults GetBestResults()
        {
            LevelsProgressDataAccess levelsProgressDataAccess = new LevelsProgressDataAccess();
            IReadonlyLevelProgress levelProgress = levelsProgressDataAccess.GetLevelProgressData(LevelIndex.SelctedLevelIndex);
            return levelProgress.BestResults;
        }

        public void InitializeLevel()
        {
            _levelCleaner.CleanLevel();

            LevelStaticData levelData = Resources.Load<LevelStaticData>("Levels/Level_" + LevelIndex.SelctedLevelIndex);

            _bricksInitializer = new BricksInitializer();
            _bricksInitializer.InitializeBricks(levelData, _bricksParent, _scoreCounter.UpdateScore);

            _levelStateMachine.EnterIn<GameplayLevelState>();
        }
    }
}
