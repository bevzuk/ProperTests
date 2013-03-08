#region Usings

using Application;
using Domain;
using NUnit.Framework;

#endregion

namespace ApplicationTests {
    [TestFixture]
    public class WhenLoadGame : ApplicationTest {
        [Test]
        public void SaveGameState() {
            var game = new Game(3);

            new GameService().Save(game, InMemoryDatabase);

            Assert.Fail("А как написать ассерт?");
        }
    }
}