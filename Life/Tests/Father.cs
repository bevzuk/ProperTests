using System;
using System.Linq;
using Domain;

namespace Tests {
    public class Father {
        public Game Game(string gameRepresentation) {
            return gameRepresentation.AsGame();
        }
    }
}