#region Usings

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace DomainTests.NotPerfect {
    [TestClass]
    public class TestClass1 {
        [TestMethod]
        [Govnotest("Reveals implementation details, Breaks incapsulation of Game.cells")]
        public void Test1() {
            var game = new Game(2);

            var expected = new bool[2,2] {{false, false}, {false, false}};
            CollectionAssert.AreEqual(expected, game.Cells);
        }

        [TestMethod]
        [Govnotest("Reveals implementation details, Breaks incapsulation of Game.cells")]
        public void Test2() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(2, 0);
            game.GiveBirth(0, 2);

            game.Step();

            var expected = new bool[3,3] {
                {false, false, false},
                {false, true, false},
                {false, false, false}
            };
            CollectionAssert.AreEqual(expected, game.Cells);
        }

        [TestMethod]
        public void Test3() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(0, 1);
            game.GiveBirth(1, 1);

            game.Step();

            Assert.IsTrue(game.Cells[1, 1].IsAlive);
        }

        [TestMethod]
        [Govnotest("Hard to understand")]
        public void Test4() {
            var game = new Game(2);

            Assert.AreEqual(false, game.Cells[0, 0].IsAlive);
            Assert.AreEqual(false, game.Cells[0, 1].IsAlive);
            Assert.AreEqual(false, game.Cells[1, 0].IsAlive);
            Assert.AreEqual(false, game.Cells[1, 0].IsAlive);
        }
    }
}