using System;

namespace HW04.Task1
{
    class Program
    {
        static void SumValues(int value1, int value2)
        {
            Console.WriteLine($"Value #1 + Value #2 = {value1 + value2}");
        }

        static void Main(string[] args)
        {
            int value1, value2;
            for(; ;)
            {
                Console.Write("Input the first value you want to sum: ");
                string value1Str = Console.ReadLine();
                if (int.TryParse(value1Str, out int parseResult1))
                {
                    value1 = parseResult1;
                    break;
                } 
                Console.WriteLine("Programm cannot parse inputted data.");
            }

            for (; ; )
            {
                Console.Write("Input the second value you want to sum: ");
                string value2Str = Console.ReadLine();
                if (int.TryParse(value2Str, out int parseResult2))
                {
                    value2 = parseResult2;
                    break;
                }
                Console.WriteLine("Programm cannot parse inputted data.");
            }

            Program.SumValues(value1, value2);
        }
    }
}
