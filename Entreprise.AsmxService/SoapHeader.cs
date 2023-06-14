using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace Entreprise.AsmxService
{
    public class AuthenticationHeader : SoapHeader
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public bool Valid
        {
            get { return
                Login.Equals("Bechir")
                    && Password.Equals("pa$$");
            }
        }
    }
}