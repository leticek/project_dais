using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm_implementace.Objects
{
    public class Zmena
    {
        public int id_zmeny { get; set; }
        public int id_lekce { get; set; }
        public int id_trenera { get; set; }
        public DateTime cas_zmeny { get; set; }
        public string druh_zmeny { get; set; }
        public int? stare_misto { get; set; }
        public int? nove_misto { get; set; }
        public DateTime? stary_cas { get; set; }
        public DateTime? novy_cas { get; set; }
        public int? stary_trenink { get; set; }
        public int? novy_trenink { get; set; }
    }
}
