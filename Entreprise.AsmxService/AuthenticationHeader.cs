using System.IO;
using System.Web.Services.Protocols;

namespace Entreprise.AsmxService
{
    public class CertificateHeader :SoapHeader
    {
        int _certificate; 
        public int Certificate { get { return _certificate; }  }

        public CertificateHeader()
        {
            int.TryParse(File.ReadAllText(@"C:\temp\client.txt"), out _certificate); 
        }


        public bool Validate() 
        {
            int clé_publique;
            int.TryParse(File.ReadAllText(@"C:\temp\serveur.txt"), out clé_publique);

            if(clé_publique + _certificate==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}