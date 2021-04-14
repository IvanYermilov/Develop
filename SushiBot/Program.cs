using Newtonsoft.Json;
using SushiBot.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SushiBot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (UI.IsProgramStart())
            {
                Log.configuration = new LoggerConfiguration(@"c:\Temp\", LoggerLevels.Debug, 30);
                
                ProductRepository productRep = new ProductRepository();
                CartRepository cartRep = new CartRepository();
                //Client client = UI.GetClientlInfo();
                UI.showMenu(productRep);
                UI.Order(productRep,cartRep);

                cartRep.Add(productRep.GetById(1), 20);
                cartRep.Add(productRep.GetById(2), 10);
                var e1 = UI.Menu(UI.CartListConvert(cartRep.cart.productList));
                Sushi e2 = UI.Menu(UI.SushiListConvert(productRep.storage.sushiList));
                string e3 = UI.Menu(UI.arrayConvert(Constants.YesNoMenu));
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
