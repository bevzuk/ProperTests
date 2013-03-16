#region Usings

using ApplicationTests.Perfect.DSL;
using Infrastructure;
using NUnit.Framework;

#endregion

namespace ApplicationTests.Perfect {
    public class ApplicationTest {
        [SetUp]
        public void Setup() {
            Context = new Context();
        }

        internal Context Context { get; private set; }

        protected InMemoryDatabase InMemoryDatabase {
            get { return Context.Get<IDatabase>() as InMemoryDatabase; }
        }

        internal void Given(params UseObjectFather[] objects) {
            InMemoryDatabase.EnsureNextTimeDataIsPulledFromDatabase();
        }

        internal ObjectFather a {
            get { return new ObjectFather(); }
        }
    }
}