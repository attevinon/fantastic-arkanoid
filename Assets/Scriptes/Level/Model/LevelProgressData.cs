using System;
using UnityEngine;
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

        public BestResultsData Clone()
        {
            var jsonClone = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<BestResultsData>(jsonClone);
        }
    }
}
