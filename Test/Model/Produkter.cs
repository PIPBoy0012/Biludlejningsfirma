using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Model
{
    public partial class Produkter
    {
        public Produkter()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProduktId { get; set; }
        public string ProduktNavn { get; set; }
        public int Pris { get; set; }
        public string Type { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
