namespace ApplicationTests.Perfect.DSL {
    internal interface IContext {
        TService Get<TService>();
    }
}