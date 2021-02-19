using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm_implementace.Objects
{
    public class Druh_treninku
    {
        public int id_treninku { get; set; }
        public string druh_treninku { get; set; }

        public override string ToString()
        {
            return id_treninku + " " + druh_treninku;
        }
    }
}
