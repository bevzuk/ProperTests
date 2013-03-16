#region usings

using Domain;
using Infrastructure;

#endregion

namespace Application {
    public class GameService : IGameService {
        public void Save(Game game, IDatabase database) {}
        public Game Load(IDatabase database) {
            return new Game(3);
        }
    }
}