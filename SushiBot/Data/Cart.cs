using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class Cart
    {
        public Dictionary<Sushi, uint> ProductList;

        public Cart()
        {
            ProductList = new Dictionary<Sushi, uint>(); 
        }

        public decimal GetCurrentCartPrice()
        {
            decimal sushiPrice;
            decimal totalPrice = default;
            uint amount;
            foreach (var position in ProductList)
            {
                sushiPrice = position.Key.Price;
                amount = position.Value;
                totalPrice += sushiPrice * amount;
            }
            return totalPrice;
        }
    }
}
