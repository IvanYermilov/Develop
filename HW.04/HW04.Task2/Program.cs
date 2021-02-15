using System;

namespace HW04.Task2
{
    class Program
    {
        static bool IsResultTrue(int value1, int value2, int supposedResult)
        {
            if ((value1 + value2) == supposedResult)
            {
                Console.WriteLine("You're right!");
                return true;
            }
            Console.WriteLine("You made a mistake.");
            return false;
        }

        static void Main(string[] args)
        {
            int value1, value2, supposedResult;
            for (; ; )
            {
                Console.Write("Input the first value you want to sum: ");
                string value1Str = Console.ReadLine();
                if (int.TryParse(value1Str, out int parsedResult1))
                {
                    value1 = parsedResult1;
                    break;
                }
                Console.WriteLine("Programm cannot parse inputted data.");
            }

            for (; ; )
            {
                Console.Write("Input the second value you want to sum: ");
                string value2Str = Console.ReadLine();
                if (int.TryParse(value2Str, out int parsedResult2))
                {
                    value2 = parsedResult2;
                    break;
                }
                Console.WriteLine("Programm cannot parse inputted data.");
            }

            for (; ;)
            {
                Console.Write("Input supposed result of two values summing: ");
                string supposedResultStr = Console.ReadLine();
                if (int.TryParse(supposedResultStr, out int parsedSupposedResult))
                {
                    supposedResult = parsedSupposedResult;
                    if (Program.IsResultTrue(value1, value2, supposedResult)) break;
                }
                else Console.WriteLine("Programm cannot parse inputted data.");
            }
        }
    }
}
