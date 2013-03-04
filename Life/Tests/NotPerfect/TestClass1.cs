#region

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Tests.NotPerfect {
    [TestClass]
    public class TestClass1 {
        [TestMethod]
        [Govnotest("Reveals implementation details, Breaks incapsulation of Game.cells")]
        public void Test1() {
            var game = new Game(2);

            var expected = new bool[2,2] {{false, false}, {false, false}};
            CollectionAssert.AreEqual(expected, game.cells);
        }

        [TestMethod]
        [Govnotest("Hard to understand")]
        public void Test2() {
            var game = new Game(2);

            Assert.AreEqual(false, game[0, 0].IsAlive);
            Assert.AreEqual(false, game[0, 1].IsAlive);
            Assert.AreEqual(false, game[1, 0].IsAlive);
            Assert.AreEqual(false, game[1, 0].IsAlive);
        }
    }
}