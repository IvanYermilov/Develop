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
            if (Ui.IsProgramStart())
            {
                Log.Configuration = new LoggerConfiguration(@"c:\Temp\", LoggerLevels.Error, 30);
                
                ProductRepository productRep = new ProductRepository();
                CartRepository cartRep = new CartRepository();
                //Client client = UI.GetClientlInfo();
                Ui.ShowMenu(productRep);
                Ui.Order(productRep,cartRep);

                cartRep.Add(productRep.GetById(1), 20);
                cartRep.Add(productRep.GetById(2), 10);
                var e1 = Ui.Menu(Ui.CartListConvert(cartRep.Cart.ProductList));
                Sushi e2 = Ui.Menu(Ui.SushiListConvert(productRep.Storage.SushiList));
                string e3 = Ui.Menu(Ui.ArrayConvert(Constants.YesNoMenu));
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
