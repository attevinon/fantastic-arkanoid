using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level.Model
{
    public class GameSession
    {
        public GameSessionData Data { get; private set; }

        public GameSession()
        {
            Data = new GameSessionData()
            {
                Score = 0,
                Time = 0f
            };
        }
    }

    public class GameSessionData : IReadonlyGameSessionData
    {
        public int Score { get; set; }
        public float Time { get; set; }
    }
}
