#region Usings

using System.Linq;
using Domain;
using NHibernate.Linq;

#endregion

namespace Infrastructure {
    public class GameRepository : IGameRepository {
        private readonly IDatabase database;

        public GameRepository(IDatabase database) {
            this.database = database;
        }

        public void Save(Game game) {
            var session = database.OpenSession();
            var doGame = session.Query<DataObjects.Game>().SingleOrDefault(_ => _.Name == game.Name)
                         ?? new DataObjects.Game();
            new GameTranslator().Persist(game, doGame);
            session.SaveOrUpdate(doGame);
            session.Flush();
        }

        public Game Load(string name) {
            var session = database.OpenSession();
            var doGame = session.Query<DataObjects.Game>().SingleOrDefault(_ => _.Name == name)
                         ?? new DataObjects.Game();
            return new GameTranslator().Reconstitute(doGame);
        }
    }
}