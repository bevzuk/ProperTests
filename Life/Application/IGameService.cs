#region Usings

using Domain;
using Infrastructure;

#endregion

namespace Application {
    public interface IGameService {
        void Save(Game game, IDatabase database);
        Game Load(string name, IDatabase database);
    }
}