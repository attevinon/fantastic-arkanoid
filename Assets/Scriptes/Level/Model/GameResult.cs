﻿using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level.Model
{
    public class GameResult : IReadonlyGameResult
    {
        public int Score { get; set; }
        public bool IsNewBestScore { get; set; }
        public float Time { get; set; }
        public bool IsNewBestTime { get; set; }
        public int BiggestCombo { get; set; }
        public bool IsNewBestCombo { get; set; }
    }
}
