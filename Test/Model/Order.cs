using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public int EjerId { get; set; }

        public virtual User Ejer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
