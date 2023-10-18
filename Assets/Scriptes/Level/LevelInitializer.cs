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
        [SerializeField] private ScoreCounter _scoreComponent;
        [SerializeField] private TimeCounter _timeCounter;
        [SerializeField] private CommonGameUI _commonGameUI;
        
        private event Action<IReadonlyGameResult, IReadonlyBestResults> _onVictory;
       
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
            _scoreComponent.Initialize(_levelStateMachine, gameSession);
            _commonGameUI.Initialize(_levelStateMachine, gameSession.Data, bestResults);
            _onVictory += _commonGameUI.ShowWinResult;
            _ = new GameResultHandler(_levelStateMachine, gameSession.Data, bestResults, _onVictory);

            InitializeLevel();
        }

        private void OnDisable()
        {
            _onVictory -= _commonGameUI.ShowWinResult;
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
            _bricksInitializer.InitializeBricks(levelData, _bricksParent, _scoreComponent.UpdateScore);

            _levelStateMachine.EnterIn<GameplayLevelState>();
        }
    }
}
