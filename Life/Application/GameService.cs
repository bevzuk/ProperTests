#region usings

using Domain;
using Infrastructure;

#endregion

namespace Application {
    public class GameService : IGameService {
        public void Save(Game game, IDatabase database) {
            new GameRepository(database).Save(game);
        }

        public Game Load(string name, IDatabase database) {
            return new GameRepository(database).Load(name);
        }
    }
}