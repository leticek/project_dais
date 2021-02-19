using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm_implementace.Objects
{
    public class Lekce
    {
        public int id_lekce { get; set; }
        public int id_mistnosti { get; set; }
        public int id_trenera { get; set; }
        public int id_treninku { get; set; }
        public DateTime cas_konani { get; set; }
        public decimal cena { get; set; }
        public char clenstvi { get; set; }

        public override string ToString()
        {
            return id_lekce + " " + id_treninku + " " + id_mistnosti + " " + id_trenera + " " + id_treninku + " " + cas_konani + " " + Decimal.Ceiling(cena) + " " + clenstvi;
        }

    }
}
