using System;

namespace HW04.Task2
{
    class Program
    {
        static void CheckResult(int value1, int value2, int supposedResult)
        {
            if ((value1 + value2) == supposedResult) Console.WriteLine("You're right!");
            else Console.WriteLine("You made a mistake.");
        }

        static void Main(string[] args)
        {
            Console.Write("Input the first value you want to sum: ");
            string value1Str = Console.ReadLine();
            if (!int.TryParse(value1Str, out int value1))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }

            Console.Write("Input the second value you want to sum: ");
            string value2Str = Console.ReadLine();
            if (!int.TryParse(value2Str, out int value2))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }

            Console.Write("Input supposed result of two values summing: ");
            string supposedResultStr = Console.ReadLine();
            if (!int.TryParse(supposedResultStr, out int supposedResult))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }

            Program.CheckResult(value1, value2, supposedResult);
        }
    }
}
