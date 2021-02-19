using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm_implementace
{
    public class Cvicenec
    {
        public int id_cvicence { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string pohlavi { get; set; }
        public DateTime datum_narozeni { get; set; }
        public string telefonni_cislo { get; set; }
        public string email { get; set; }
        public string adresa { get; set; }
        public char clen_klubu { get; set; }
        public override string ToString()
        {
            return id_cvicence + " " + jmeno + " " + prijmeni + " " + pohlavi + " " + datum_narozeni + " " + telefonni_cislo + " " + email + " " + adresa + " " + clen_klubu;
        }
    }

}
