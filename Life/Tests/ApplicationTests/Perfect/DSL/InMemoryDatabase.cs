#region Usings

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Infrastructure;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

#endregion

namespace ApplicationTests.Perfect.DSL {
    public class InMemoryDatabase : IDatabase {
        private readonly AutoResetEvent connectionAvailable = new AutoResetEvent(true);
        private readonly ISession session;
        private ITransaction transaction;

        public InMemoryDatabase() {
            var configuration = new Configuration().Configure("app.config");
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
            //closing session will destroy in-memory database
        }

        public void BeginTransaction(ISession session) {
            connectionAvailable.WaitOne();
            transaction = session.BeginTransaction();
        }

        public void CommitTransaction(ISession session) {
            transaction.Commit();
            connectionAvailable.Set();
        }

        public void ApplyChanges() {
            session.Flush();
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

        public object GetId(object entity) {
            return session.GetIdentifier(entity);
        }
    }
}