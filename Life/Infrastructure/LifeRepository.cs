using System.Collections.Generic;
using Domain;
using NHibernate.Linq;
using System.Linq;

namespace Infrastructure {
    public class LifeRepository {
        private readonly IDatabase database;

        public LifeRepository(IDatabase database) {
            this.database = database;
        }

        public List<Game> LoadGames() {
            using (var session = database.OpenSession()) {
                var games = session.Query<Game>().ToList();
                return games;
            }
        }
    }
}