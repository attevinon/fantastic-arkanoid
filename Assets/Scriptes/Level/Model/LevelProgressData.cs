using System;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level.Model
{
    [Serializable]
    public class LevelProgressData : IReadonlyLevelProgress
    {
        public bool IsOpened { get; set; }
        public bool IsPassed { get; set; }
        public BestResultsData BestResultsData { get; set; }
        public IReadonlyBestResults BestResults => BestResultsData;
    }

    [Serializable]
    public class BestResultsData : IReadonlyBestResults
    {
        public int BestScore {get; set; }
        public float BestTime {get; set; }
        public int BestCombo {get; set; }

        public BestResultsData Clone()
        {
            var newBestResultsData = new BestResultsData()
            {
                BestScore = this.BestScore,
                BestTime = this.BestTime,
                BestCombo = this.BestCombo
            };

            return newBestResultsData;
        }
    }
}
