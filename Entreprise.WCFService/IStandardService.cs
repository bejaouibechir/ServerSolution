

using System.ServiceModel;

namespace Entreprise.WCFService
{
    [ServiceContract]
    public interface IStandardService
    {
        [OperationContract]
        string Diffusion(string message);
      
    }
}
