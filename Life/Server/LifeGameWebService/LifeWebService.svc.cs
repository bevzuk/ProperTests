#region Usings

using Application;
using Domain;
using Infrastructure;

#endregion

namespace LifeGameWebService {
    public class LifeWebService : ILifeWebService {
        public Game Load(string name) {
            return new GameService().Load(name, new RealDatabase());
        }
    }
}