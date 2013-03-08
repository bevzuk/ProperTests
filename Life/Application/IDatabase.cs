using NHibernate;

namespace Application {
    public interface IDatabase {
        ISession OpenSession();
        void Close(ISession session);
    }
}