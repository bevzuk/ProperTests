#region Usings

using Domain;
using NUnit.Framework;
using Tests.Perfect;

#endregion

namespace Tests {
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
    }
}