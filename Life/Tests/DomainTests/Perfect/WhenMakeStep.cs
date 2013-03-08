#region

using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace DomainTests.Perfect {
    [TestClass]
    public class WhenMakeStep : DomainTest {
        [TestMethod]
        public void AnyLiveCellWithZeroNeighborsDies() {
            var game = new Game(3);
            game.GiveBirth(1, 1);

            game.Step();

            AssertThat.AreEqual(@"...
                                  ...
                                  ...", game);
        } 

        [TestMethod]
        public void AnyLiveCellWithOneNeighborsDies() {
            var game = new Game(3);
            game.GiveBirth(0, 0);
            game.GiveBirth(1, 1);

            game.Step();

            AssertThat.AreEqual(@"...
                                  ...
                                  ...", game);
        } 

        [TestMethod]
        public void AnyLiveCellWithThreeNeighborsLives() {
            game.GiveBirth(2, 0);
        public void AnyLiveCellWithFourNeighborsDiesByOvercrowding() {
            var game = Create.Game(@"x.x
                                     .x.
                                     x.x");

            game.Step();

            Assert.IsTrue(game[1, 1].IsDead);
        }

        [TestMethod]
        public void AnyLiveCellWithThreeNeighborsLives2() {
            var game = Create.Game(@"x.x
                                     ...
                                     x..");

            game.Step();

            AssertThat.AreEqual(@"...
                                  .x.
                                  ...", game);
        }
    }
}