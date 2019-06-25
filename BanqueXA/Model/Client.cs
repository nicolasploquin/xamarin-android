using System.Collections.Generic;
using System.Linq;
namespace Eni.Banque.Android.Model
{
    public class Client
    {
 
        public long Id { get; set; }

        private string nom = "";
        private string prenom = "";

        public string Nom
        {
            get { return nom; }
            set { nom = value.ToUpper(); }
        }
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value.Length > 0 ? string.Join("-", value.ToLower()
                    .Split('-').Select(
                        p => p.Substring(0, 1).ToUpper() + p.Substring(1)
                    )
                ) : "";
            }
        }
        public string Tel { get; set; }

    }
}