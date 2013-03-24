using Ninject;

namespace ApplicationTests.Perfect.DSL {
    internal class Context : IContext {
        public Context() : this(new StandardKernel(new TestDependencyContainer())) {}

        private Context(StandardKernel kernel) {
            Kernel = kernel;
        }

        public StandardKernel Kernel { get; private set; }

        public TService Get<TService>() {
            return Kernel.Get<TService>();
        }
    }
}