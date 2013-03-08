using Domain;

namespace DomainTests.Perfect {
    public class Father {
        public Game Game(string gameRepresentation) {
            return gameRepresentation.AsGame();
        }
    }
}