#region Usings

using NUnit.Framework;

#endregion

namespace ApplicationTests.Perfect {
    public class ApplicationTest {
        [SetUp]
        public void Setup() {
            InMemoryDatabase = new InMemoryDatabase();
        }

        protected InMemoryDatabase InMemoryDatabase { get; set; }
    }
}