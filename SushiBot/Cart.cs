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

        public void Add(Sushi sushi, uint quantity)
        {
            if (!productList.ContainsKey(sushi)) productList.Add(sushi, quantity);
            else productList[sushi] += quantity;
        }
        public void Substract(Sushi sushi, uint quantity)
        {
            if (productList.TryGetValue(sushi, out uint inCartSushiQuantity))
            {
                if (inCartSushiQuantity < quantity) productList.Remove(sushi);
                else productList[sushi] -= quantity;
            }
        }
    }
}
