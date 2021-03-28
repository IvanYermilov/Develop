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
            Log.Configuration = new LoggerConfiguration();
            Log.Info("KeK");
            Console.ReadKey();
        }
    }
}
