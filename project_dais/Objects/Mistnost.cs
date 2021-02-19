using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm_implementace.Objects
{
    public class Mistnost
    {
        public int id_mistnosti { get; set; }
        public int kapacita_mistnosti { get; set; }

        public override string ToString()
        {
            return id_mistnosti + " " + kapacita_mistnosti;
        }

    }
}
