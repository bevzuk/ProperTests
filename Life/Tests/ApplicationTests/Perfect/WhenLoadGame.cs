#region Usings

using System.Linq;
using Application;
using NUnit.Framework;

#endregion

namespace ApplicationTests.Perfect {
    [TestFixture]
    public class WhenSaveGame : ApplicationTest {
        [Test]
        public void LoadGameWithState() {
            var game = Create.Game(name: "Life game");

            var actualGames = new GameService().LoadGames(LifeRepository);

            Assert.AreEqual("Life game", actualGames.Single().Name);
        }
    }
}