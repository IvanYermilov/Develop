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
                Repository rep = new Repository();
                Sushi s = UI.Menu(UI.SushiListConvert(rep.storage.sushiList));
                //Client client = UI.GetClientlInfo();
                Console.ReadKey();
            }
            
        }
    }
}
