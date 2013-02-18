#region

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Tests {
    [TestClass]
    public class WhenMakeStep : DomainTest {
        [TestMethod]
        public void AnyLiveCellWithZeroNeighborsDies() {
            var game = new Game(3);
            game.GiveBirth(2, 2);

            game.Step();

            AssertThat.AreEqual(@"...
                                  ...
                                  ...", game);
        } 
    }
}