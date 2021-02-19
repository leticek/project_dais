using System;

namespace orm_implementace.Objects
{
    public class Trener
    {
        public int id_trenera { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string pohlavi { get; set; }
        public DateTime datum_narozeni { get; set; }
        public string telefonni_cislo { get; set; }
        public string email { get; set; }
        public string adresa { get; set; }

        public override string ToString()
        {
            return id_trenera + " " + jmeno + " " + prijmeni + " " + pohlavi + " " + datum_narozeni + " " + telefonni_cislo + " " + email + " " + adresa;
        }
    }
}
