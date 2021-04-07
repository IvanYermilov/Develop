using Newtonsoft.Json;
using SushiBot.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SushiBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository rep = new Repository();
            int i = 0;
            while (true)
            {
                Log.configuration = new LoggerConfiguration(@"c:\Temp\", LoggerLevels.Debug, 30);
                Log.Debug("LoL");
                Log.Info("KeK");
                Log.Error("AZaZa");
                rep.LogTesting();
                i++;
                if (i == 1) break;
            }
            //while(true)
            //{
            //    if (UI.Menu().Equals(Constants.PostitiveAnswer)) Console.WriteLine("Nice");
            //}


            Console.WriteLine(JsonConvert.SerializeObject(rep.storage, Formatting.Indented));

            
            Console.ReadKey();
        }
    }
}
