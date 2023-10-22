namespace FantasticArkanoid.Level.ModelAbstractions
{
    public interface IReadonlyGameResult
    {
        public int Score { get; }
        public bool IsNewBestScore { get; }
        public float Time { get; }
        public bool IsNewBestTime { get; }
        public int BiggestCombo { get; }
        public bool IsNewBestCombo { get; }
    }
}
