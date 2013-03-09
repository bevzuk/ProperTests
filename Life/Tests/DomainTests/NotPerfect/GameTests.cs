#region Usings

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace DomainTests.NotPerfect {
    [TestClass]
    public class GameTests {
        [TestMethod]
        [Govnotest("Reveals implementation details, Breaks incapsulation of Game.cells")]
        public void CanCreateGame() {
            var game = new Game(2);

            var expected = new[,] {{false, false}, {false, false}};
            CollectionAssert.AreEqual(expected, game.Cells);
        }

        [TestMethod]
        [Govnotest("Hard to understand")]
        public void CanCreateGameAnySize() {
            var game = new Game(3);

            Assert.IsFalse(game.Cells[0, 0]);
            Assert.IsFalse(game.Cells[0, 1]);
            Assert.IsFalse(game.Cells[0, 2]);
            Assert.IsFalse(game.Cells[1, 0]);
            Assert.IsFalse(game.Cells[1, 1]);
            Assert.IsFalse(game.Cells[1, 2]);
            Assert.IsFalse(game.Cells[2, 0]);
            Assert.IsFalse(game.Cells[2, 1]);
            Assert.IsFalse(game.Cells[2, 1]);
        }

        [TestMethod]
        public void TestWithTwoNeighbors() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(0, 1);
            game.GiveBirth(1, 1);

            game.Step();

            Assert.IsTrue(game.Cells[1, 1]);
        }

        [TestMethod]
        public void TestWithThreeNeighbors() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(0, 2);
            game.GiveBirth(2, 0);

            game.Step();

            Assert.IsTrue(game.Cells[1, 1]);
        }

        [TestMethod]
        [Govnotest("Reveals implementation details, Breaks incapsulation of Game.cells")]
        public void TestAllCellsWithThreeNeighbors() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(2, 0);
            game.GiveBirth(0, 2);

            game.Step();

            var expected = new[,] {
                {false, false, false},
                {false, true, false},
                {false, false, false}
            };
            CollectionAssert.AreEqual(expected, game.Cells);
        }
    }
}