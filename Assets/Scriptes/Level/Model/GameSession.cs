using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.Level.Model
{
    public class GameSession
    {
        public GameSessionData Data { get; private set; }

        public GameSession()
        {
            Data = new GameSessionData() { Score = 0 };
        }
    }

    public class GameSessionData : IReadonlyGameSessionData
    {
        public int Score {get; set;}
    }
}
