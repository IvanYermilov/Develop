using SushiBot.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class CartRepository: ICartRepository
    {
        public Cart cart = new Cart();
        public void Add(Sushi sushi, uint quantity)
        {
            if (!cart.productList.ContainsKey(sushi)) cart.productList.Add(sushi, quantity);
            else cart.productList[sushi] += quantity;
        }
        public void Substract(Sushi sushi, uint quantity)
        {
            if (cart.productList.TryGetValue(sushi, out uint inCartSushiQuantity))
            {
                if (inCartSushiQuantity < quantity) cart.productList.Remove(sushi);
                else cart.productList[sushi] -= quantity;
            }
        }
    }
}
