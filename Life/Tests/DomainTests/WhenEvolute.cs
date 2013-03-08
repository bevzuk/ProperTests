#region Usings

using DomainTests.Perfect;
using NUnit.Framework;

#endregion

namespace DomainTests {
    [TestFixture]
    public class WhenEvolute : DomainTest {
        [Test]
        public void AnyLiveCellWithZeroNeighborsDies() {
            var game = Create.Game(@"...
                                     .x.
                                     ...");

            game.Step();

            Assert.That(game, Equivalent.To(@"...
                                              ...
                                              ..."));
        }

        [Test]
        public void AnyDeadCellWithThreeNeighborsArises() {
            var game = Create.Game(@"x.x
                                     ...
                                     x..");

            game.Step();

            Assert.That(game, Equivalent.To(@"...
                                              .x.
                                              ..."));
        }
    }
}