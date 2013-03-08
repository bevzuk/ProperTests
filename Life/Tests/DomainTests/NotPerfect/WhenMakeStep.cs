#region usings

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace DomainTests.NotPerfect {
    [TestClass]
    public class GameTests {
        [TestMethod]
        public void TestWithTwoNeighbors() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(0, 1);
            game.GiveBirth(1, 1);

            game.Step();

            Assert.IsTrue(game[1, 1].IsAlive);
        }

        [TestMethod]
        public void TestWithThreeNeighbors() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(0, 2);
            game.GiveBirth(2, 0);

            game.Step();

            Assert.IsTrue(game[1, 1].IsAlive);
        }
    }
}