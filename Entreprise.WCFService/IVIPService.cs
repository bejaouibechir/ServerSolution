using System.ServiceModel;

namespace Entreprise.WCFService
{
    [ServiceContract]
    public interface IVIPService :IStandardService
    {
        [OperationContract]
        void Redifusion();

        [OperationContract]
        void Enregsitrement();
    }
}
