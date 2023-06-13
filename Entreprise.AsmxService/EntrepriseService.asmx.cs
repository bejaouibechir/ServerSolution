using System.Web.Services;

namespace Entreprise.AsmxService
{
    /// <summary>
    /// Summary description for EntrepriseService
    /// </summary>
    [WebService(Namespace = "http://www.contoso.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class EntrepriseService //: System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            

            return "Hello World";
        }
    }
}
