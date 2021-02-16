using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public float CartTotal { get; set; }
        public int QuantityTotal { get; set; }

        public Game Game { get; set; }
    }
}
