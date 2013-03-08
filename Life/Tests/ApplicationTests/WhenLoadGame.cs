using Application;
using NUnit.Framework;

namespace ApplicationTests {
    [TestFixture]
    public class WhenLoadGame : ApplicationTest {
        [Test]
        public void CanSaveGame() {
            var gameService = new GameService();
        }
    }
}