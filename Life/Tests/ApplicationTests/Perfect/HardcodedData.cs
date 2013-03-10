using System.Collections.Generic;
using Domain;

namespace ApplicationTests.Perfect {
    public class HardcodedData {
        private readonly ICollection<Game> games = new List<Game>();

        public void Add(Game game) {
            games.Add(game);
        }
    }
}