#region Usings

using Infrastructure;
using NUnit.Framework;

#endregion

namespace ApplicationTests.Perfect {
    public class ApplicationTest {
        [SetUp]
        public void Setup() {
            InMemoryDatabase = new InMemoryDatabase();
            Create = new ApplicationFather(InMemoryDatabase);
            LifeRepository = new LifeRepository(InMemoryDatabase);
        }

        protected InMemoryDatabase InMemoryDatabase { get; private set; }
        protected ApplicationFather Create { get; private set; }
        protected LifeRepository LifeRepository { get; private set; }
    }

    public class ApplicationFather {
        private readonly InMemoryDatabase database;

        public ApplicationFather(InMemoryDatabase database) {
            this.database = database;
        }

        public Game Game(string name = null) {
            var game = new Game {Name = name};
            database.HardcodedData.Add(game);
            return game;
        }
    }
}