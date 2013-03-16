using Infrastructure;
using NHibernate;
using NHibernate.Cfg;

namespace ApplicationTests.NotPerfect {
    public class Database : IDatabase {
        private readonly ISessionFactory db;

        public Database() {
            db = new Configuration().Configure().BuildSessionFactory();
        }

        public ISession OpenSession() {
            return db.OpenSession();
        }

        public void Close(ISession session) {
            session.Close();
        }
    }
}