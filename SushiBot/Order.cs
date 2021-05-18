using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class Order
    {
        public Guid ID { get; }
        public CartRepository Cart { get; }
        public Order(CartRepository cartRep)
        {
            ID = Guid.NewGuid();
            Cart = cartRep;
        }
    }
}
