namespace FantasticArkanoid.Level.ModelAbstractions
{
    public interface IReadonlyLevelProgress
    {
        public bool IsOpened { get; }
        public bool IsPassed { get; }
        public IReadonlyBestResults BestResults { get; }
    }
}
