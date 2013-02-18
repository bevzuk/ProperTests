#region

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Tests {
    [TestClass]
    public class WhenStartGame : DomainTest {
        [TestMethod]
        public void CanCreateGameOfSize2() {
            var game = new Game(2);
            AssertThat.AreEqual(@"..
                                  ..", game);
        }

        [TestMethod]
        public void CanCreateGameOfSize3() {
            var game = new Game(3);
            AssertThat.AreEqual(@"...
                                  ...
                                  ...", game);
            Assert.IsFalse(game[1, 1].IsAlive);
            Assert.IsFalse(game[1, 2].IsAlive);
            Assert.IsFalse(game[1, 3].IsAlive);
        }

        [TestMethod]
        public void CanSetAliveCells() {
            var game = new Game(2);
            game.GiveBirth(1, 1);
            game.GiveBirth(1, 2);
            AssertThat.AreEqual(@"xx
                                  x.", game);
        }
    }
}