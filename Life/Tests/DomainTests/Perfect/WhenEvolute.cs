#region Usings

using Common;
using NUnit.Framework;

#endregion

namespace DomainTests.Perfect {
    [TestFixture]
    public class WhenEvolute : DomainTest {
        [Test]
        public void AnyLiveCellWithZeroNeighborsDies() {
            var game = Create.Game(@"...
                                     .x.
                                     ...");

            game.Step();

            Assert.That(game, IsEquivalent.To(@"...
                                                ...
                                                ..."));
        }

        [Test]
        public void AnyDeadCellWithThreeNeighborsArises() {
            var game = Create.Game(@"x.x
                                     ...
                                     x..");

            game.Step();

            Assert.That(game, IsEquivalent.To(@"...
                                                .x.
                                                ..."));
        }
    }
}