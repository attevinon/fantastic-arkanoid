using System;
using UnityEngine;
using FantasticArkanoid.Level.Model;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level
{
    public class GameResultHandler
    {
        private LevelStateMachine _levelStateMachine;
        private BestResultsData _bestResults;
        private IReadonlyGameSessionData _gameSession;
        private Action<IReadonlyGameResult, IReadonlyBestResults> _onVictory;

        public GameResultHandler(LevelStateMachine levelStateMachine, IReadonlyGameSessionData gameSession,
            IReadonlyBestResults bestResults, Action<IReadonlyGameResult, IReadonlyBestResults> onVictory)
        {
            _levelStateMachine = levelStateMachine;
            _bestResults = bestResults as BestResultsData;
            _gameSession = gameSession;
            BricksCounter.OnBricksDisabled += OnGameEnded;
            _onVictory = onVictory;
        }

        public void OnGameEnded()
        {
            Debug.Log("OnGameEnded()");
            if (_levelStateMachine.IsCurrentState<GameplayLevelState>())
            {
                BestResultsData tempBestResults = new BestResultsData();

                if(_bestResults != null)
                {
                    tempBestResults = _bestResults.Clone();
                }

                GameResult gameResult = new GameResult() {
                    Score = _gameSession.Score,
                    IsNewBestScore = tempBestResults.BestScore < _gameSession.Score
                };

                tempBestResults.BestScore = gameResult.IsNewBestScore ? gameResult.Score : tempBestResults.BestScore;

                _bestResults = tempBestResults;
                _onVictory?.Invoke(gameResult, tempBestResults);
                BricksCounter.OnBricksDisabled -= OnGameEnded;

                LevelProgressData levelProgressData = new LevelProgressData()
                {
                    IsOpened = true,
                    IsPassed = true,
                    BestResultsData = _bestResults
                };

                LevelsProgressDataAccess levelsProgressDataAccess = new LevelsProgressDataAccess();
                levelsProgressDataAccess.SaveLevelProgressData(LevelIndex.SelctedLevelIndex, levelProgressData);
            }
        }
    }
}
