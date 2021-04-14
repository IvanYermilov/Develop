using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class Cart
    {
        public Dictionary<Sushi, uint> productList;

        public Cart()
        {
            productList = new Dictionary<Sushi, uint>(); 
        }
    }
}
