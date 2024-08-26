namespace FantasticArkanoid.Level.ModelAbstractions
{
    public interface IReadonlyGameSessionData
    {
        public int Score { get; }
        public float Time { get; }
    }
}
