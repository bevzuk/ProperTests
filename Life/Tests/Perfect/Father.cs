using Domain;

namespace Tests.Perfect {
    public class Father {
        public Game Game(string gameRepresentation) {
            return gameRepresentation.AsGame();
        }
    }
}