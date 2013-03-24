#region Usings

using Application;
using Common;
using NUnit.Framework;

#endregion

namespace ApplicationTests.Perfect {
    [TestFixture]
    public class WhenLoadGame : ApplicationTest {
        private readonly GameService service = new GameService();

        [Test]
        public void SaveGameState() {
            Given(a.Game(name: "SampleGame",
                         field: @"...
                                  .x.
                                  ..."));

            var game = service.Load("SampleGame", InMemoryDatabase);

            Assert.That(game, IsEquivalent.To(@"...
                                                .x.
                                                ..."));
        }
    }
}