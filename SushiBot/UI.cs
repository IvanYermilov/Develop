using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class UI
    {
        public static string Menu()
        {
            int a = Console.CursorTop;
            int index = 0;
            string[] strArr = { Constants.PostitiveAnswer, Constants.NegativeAnswer };
            for (; ; )
            {
                Console.CursorVisible = false;
                //Console.WriteLine();
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;

                    }
                    Console.WriteLine(strArr[i]);
                    Console.ResetColor();
                }
                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.DownArrow):
                        index++;
                        if (index > strArr.Length - 1) index = 0;
                        break;
                    case (ConsoleKey.UpArrow):
                        index--;
                        if (index < 0) index = strArr.Length - 1;
                        break;
                    case (ConsoleKey.Enter):
                        return strArr[index];
                }
                Console.SetCursorPosition(0, a);
            }
        }
    }
}
