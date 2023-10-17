using System;
using System.Collections.Generic;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level.Model
{
    [Serializable]
    public class LevelsProgress : IReadonlyLevelsProgress
    {
        public List<LevelProgressData> DatasList;
        public LevelsProgress()
        {
            DatasList = new List<LevelProgressData>();
        }

        public IReadOnlyList<IReadonlyLevelProgress> GetReadonlyDatas() => DatasList;
    }
}
