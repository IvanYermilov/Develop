using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SushiBot.Attributes;
using SushiBot.Exceptions;

namespace SushiBot
{

    
    class Cart
    {
        [MaxProductsAmountInPosition(MaxQuantity = 50)]
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
        public void CheckPositionProductsAmount(uint productsAmount)
        {
            Type attributeType = typeof(MaxProductsAmountInPositionAttribute);
            Type cartType = GetType();
            var a = (MaxProductsAmountInPositionAttribute)cartType.GetMembers()
                .First(_ => _.Name == "ProductList").GetCustomAttribute(attributeType);
            if (productsAmount > a.MaxQuantity) 
                throw new CartLimitExceededException("Sushi amount in cart position must be less than 50.");
        }
    }
}
