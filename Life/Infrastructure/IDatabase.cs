#region Usings

using NHibernate;
using NHibernate.Cfg;

#endregion

namespace Infrastructure {
    public interface IDatabase {
        ISession OpenSession();
        void Close(ISession session);
    }


    public class RealDatabase : IDatabase {
        public ISession OpenSession() {
            return null;
        }

        public void Close(ISession session) {
            session.Close();
        }
    }
}