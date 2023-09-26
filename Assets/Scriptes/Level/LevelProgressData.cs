using System;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    [Serializable]
    public class LevelsProgress
    {
        public List<LevelProgressData> LevelsProgressDatas;
        public LevelsProgress()
        {
            LevelsProgressDatas = new List<LevelProgressData>();
        }
    }

    [Serializable]
    public class LevelProgressData
    {
        public bool IsOpened;
        public bool IsPassed;
    }
}
