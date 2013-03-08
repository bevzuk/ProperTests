#region Usings

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace DomainTests.Perfect {
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
        }

        [TestMethod]
        public void CanSetAliveCells() {
            var game = new Game(2);
            game.GiveBirth(0, 0);
            game.GiveBirth(0, 1);
            AssertThat.AreEqual(@"xx
                                  ..", game);
        }
    }
}