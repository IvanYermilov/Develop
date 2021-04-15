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
        public Cart Cart = new Cart();
        public void Add(Sushi sushi, uint amount)
        {
            if (!Cart.ProductList.ContainsKey(sushi)) Cart.ProductList.Add(sushi, amount);
            else Cart.ProductList[sushi] += amount;
        }

        public void EditValue( KeyValuePair<Sushi, uint> cartPosition, uint sushiAmount)
        {
            Cart.ProductList[cartPosition.Key] = sushiAmount;
        }

        public Dictionary<Sushi,uint> GetAll() 
        {
            if (IsPositionsInCart())
            {
                var cartPositionsList = Cart.ProductList;
                Log.Info($"All positions exist in Cart were retrieved.");
                return cartPositionsList;
            }
            else Log.Info("Cart is empty.");
            return null;
        }

        public bool IsPositionsInCart()
        {
            return Cart.ProductList.Count != 0;
        }
    }
}
