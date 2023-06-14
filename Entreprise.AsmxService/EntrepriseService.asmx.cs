using System.Configuration;
using System.Diagnostics;
using System.Security.Authentication;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Entreprise.AsmxService
{
    /// <summary>
    /// Summary description for EntrepriseService
    /// </summary>
    [WebService(Namespace = "http://constoso.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]

    //Heriter de WebService est optionel, on l'utilise dans le cas ou le service est consommé par une 
    //application web 
    public class EntrepriseService //: System.Web.Services.WebService 
    {
        public AuthenticationHeader authHeader;
        private int _port1;
        private int _port2;
        private string _connectionstring;
        private string _connectionstring2;
        public EntrepriseService()
        {
            authHeader = new AuthenticationHeader();
            _port1 = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
            _port2 = int.Parse(ConfigurationManager.AppSettings[1].ToString());
            _connectionstring = ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;
            _connectionstring2 = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        }

        [WebMethod] //Pour exposer le service à l'exteieur il faut le décorer avec l'attribut WebMethod

        [SoapHeader("authHeader", Direction = SoapHeaderDirection.In)]
        public double Add(double a, double b)
        {
            try
            {
                if(authHeader != null && authHeader.Valid==true) 
                {
                    authHeader.DidUnderstand = true;
                    
                }
                else
                {
                    authHeader.DidUnderstand = false;
                    throw new AuthenticationException("Paramètres de connexion non correctes");
                }
                return a + b;

            }
            catch (AuthenticationException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
            
        }

        [WebMethod]
        public void Authenticate(string username, string password)
        {
            string[] credentials = DataBaseInfo().Split(';');
            if (!(credentials[0] =="Bechir" && credentials[1] == "pa$$"))
            {
                throw new AuthenticationException("L'utilisateur n'est pas authentifié");
            }
        }

        //
        private string DataBaseInfo()
        {
            return "Bechir;pa$$";
        }


        [WebMethod(Description = "Soustraire")] //Pour exposer le service à l'exteieur il faut le décorer avec l'attribut WebMethod
        public double Substract(double a, double b)=>a - b;



    }
}
