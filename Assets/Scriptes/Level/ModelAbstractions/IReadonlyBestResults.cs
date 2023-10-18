namespace FantasticArkanoid.Level.ModelAbstractions
{
    public interface IReadonlyBestResults
    {
        public int BestScore { get; }
        public float BestTime { get; }
    }
}
