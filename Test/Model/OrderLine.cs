using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Model
{
    public partial class OrderLine
    {
        public int OrderLines { get; set; }
        public int Antal { get; set; }
        public int SamletPris { get; set; }
        public int OrderId { get; set; }
        public int ProduktId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Produkter Produkt { get; set; }
    }
}
