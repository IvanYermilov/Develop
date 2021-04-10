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
                Client client = UI.GetClientlInfo();
                //while(true)
                //{
                //    if (UI.Menu().Equals(Constants.PostitiveAnswer)) Console.WriteLine("Nice");
                //}
                rep.GetAll();
                //
            }
            Console.ReadKey();
        }
    }
}
