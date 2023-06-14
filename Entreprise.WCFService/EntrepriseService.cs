using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Entreprise.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EntrepriseService : IEntrepriseService,IStandardService, IVIPService
    {
        public string Diffusion(string message)
        {
            return $"Le message est {message}";
        }

        #region fonctionalités VIP
        public void Enregsitrement()
        {
            Debug.WriteLine("Enregistrement des match");
        }

        public void Redifusion()
        {
            Debug.WriteLine("Rediffusion des matchs");
        }
        #endregion

        public void Test(string content, string path)
        {
            File.WriteAllText(path, content);
        }
    }
}
