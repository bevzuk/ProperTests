using Application;
using Infrastructure;
using Ninject.Modules;

namespace ApplicationTests.Perfect.DSL {
    internal class TestDependencyContainer : NinjectModule {
        public override void Load() {
            var database = new InMemoryDatabase();
            var gameService = new GameService();

            Kernel.Bind<IDatabase>().ToMethod(_ => database);
            Kernel.Bind<IGameService>().ToMethod(_ => gameService);
        }
    }
}