using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level.Model
{
    public class GameResult : IReadonlyGameResult
    {
        public int Score { get; set; }
        public bool IsNewBestScore { get; set; }
    }
}
