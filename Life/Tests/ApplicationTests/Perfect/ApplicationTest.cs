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

// ReSharper disable InconsistentNaming
        internal ObjectFather a {
// ReSharper restore InconsistentNaming
            get { return new ObjectFather(Context); }
        }

// ReSharper disable InconsistentNaming
        internal ObjectFather an {
// ReSharper restore InconsistentNaming
            get { return a; }
        }
    }
}