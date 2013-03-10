#region usings

using System.Collections.Generic;
using Domain;
using Infrastructure;

#endregion

namespace Application {
    public class GameService {
        public List<Game> LoadGames(LifeRepository repository) {
            return repository.LoadGames();
        }
    }
}