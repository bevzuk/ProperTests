#region Usings

using Application;
using Common;
using Domain;
using NUnit.Framework;

#endregion

namespace ApplicationTests.Perfect {
    [TestFixture]
    public class WhenLoadGame : ApplicationTest {
        private readonly GameService service = new GameService();

        [Test]
        public void SaveGameState() {
            Given(a.Game(@"...
                           .x.
                           ..."));

            var game = service.Load(InMemoryDatabase);

            Assert.That(game, IsEquivalent.To(@"...
                                                .x.
                                                ..."));
        }
    }
}