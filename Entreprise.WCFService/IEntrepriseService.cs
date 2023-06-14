using System.Runtime.Serialization;
using System.ServiceModel;


namespace Entreprise.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEntrepriseService
    {
        [OperationContract]
        void Test(string content,string path);

    }

   
}
