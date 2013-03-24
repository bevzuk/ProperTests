#region Usings

using System.ServiceModel;
using Domain;

#endregion

namespace LifeGameWebService {
    [ServiceContract]
    public interface ILifeWebService {
        [OperationContract]
        Game Load(string name);
    }
}