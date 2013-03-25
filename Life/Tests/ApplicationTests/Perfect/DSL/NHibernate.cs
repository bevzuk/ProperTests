using NHibernate.Cfg;

namespace ApplicationTests.Perfect.DSL {
    public static class NHibernate {
        public static Configuration Configuration { get; private set; }
        static NHibernate() {
            Configuration = new Configuration().Configure("app.config");
        }
    }
}