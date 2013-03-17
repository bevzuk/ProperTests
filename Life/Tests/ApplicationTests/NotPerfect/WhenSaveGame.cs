#region

using System.Linq;
using Application;
using ApplicationTests.Perfect.DSL;
using Domain;
using NHibernate.Linq;
using NUnit.Framework;

#endregion

namespace ApplicationTests.NotPerfect {
    [TestFixture]
    public class WhenSaveGame {
        [Test]
        public void GameIsSaved() {
            var database = new InMemoryDatabase();
            var game = new Game(2, "Test game");
            game.GiveBirth(0, 0);
            game.GiveBirth(0, 1);

            new GameService().Save(game, database);

            var session = database.OpenSession();
            var gameFromDb = session.Query<Infrastructure.DataObjects.Game>().Single(_ => _.Name == "Test game");
            Assert.AreEqual(2, gameFromDb.Cells.Count());

            Assert.AreEqual(0, gameFromDb.Cells.First().X);
            Assert.AreEqual(0, gameFromDb.Cells.First().Y);

            Assert.AreEqual(1, gameFromDb.Cells.Last().X);
            Assert.AreEqual(0, gameFromDb.Cells.Last().Y);
        }
    }
}