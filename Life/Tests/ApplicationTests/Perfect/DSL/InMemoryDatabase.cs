#region Usings

using System;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

#endregion

namespace ApplicationTests.Perfect.DSL {
    public class InMemoryDatabase : IDatabase {
        private readonly ISession session;
        private ITransaction transaction;

        public InMemoryDatabase() {
            var configuration = NHibernate.Configuration;
            var sessionFactory = configuration.BuildSessionFactory();
            session = sessionFactory.OpenSession();
            new SchemaExport(configuration).Execute(false, true, false, session.Connection, null);
        }

        public ISession OpenSession() {
            return session;
        }

        public void Close(ISession session) {
            session.Flush();
            session.Clear();
        }

        public void EnsureNextTimeDataIsPulledFromDatabase() {
            session.Clear();
        }

        public T Load<T>(object id) {
            return session.Load<T>(id);
        }

        public IQueryable<T> Query<T>() {
            EnsureNextTimeDataIsPulledFromDatabase();
            return session.Query<T>();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate) {
            return Query<T>().Where(predicate);
        }
    }
}