using Application;
using Domain;
using Infrastructure;

namespace ApplicationTests.Perfect.DSL {
    internal class ObjectFather {
        private readonly IContext context;

        public ObjectFather(IContext context) {
            this.context = context;
        }

        public UseObjectFather Game(string field = ".", string name = null) {
            var game = field.AsGame(name);
            var service = context.Get<IGameService>();
            var database = context.Get<IDatabase>();
            service.Save(game, database);

            return new UseObjectFather();
        }
    }
}