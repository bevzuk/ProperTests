using NHibernate;

namespace Infrastructure {
    public interface IDatabase {
        ISession OpenSession();
        void Close(ISession session);
    }
}