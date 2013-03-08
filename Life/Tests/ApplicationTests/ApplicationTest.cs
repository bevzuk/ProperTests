#region Usings

using NUnit.Framework;

#endregion

namespace ApplicationTests {
    public class ApplicationTest {
        [SetUp]
        public void Setup() {
            InMemoryDatabase = new InMemoryDatabase();
        }

        protected InMemoryDatabase InMemoryDatabase { get; set; }
    }
}