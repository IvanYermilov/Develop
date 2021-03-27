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
            int index = 0;
            Console.CursorVisible = false;
            string[] strArr = {"one", "two", "three"};
            for (; ; )
            {
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(strArr[i]);
                }
                ConsoleKey c = Console.ReadKey().Key;
                Console.Clear();
                if (c == ConsoleKey.UpArrow) index++;


                Console.ReadKey();
            }
        }
    }
}
