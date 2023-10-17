namespace FantasticArkanoid.Level.ModelAbstractions
{
    public interface IReadonlyGameResult
    {
        public int Score { get; }
        public bool IsNewBestScore { get; }
    }
}
