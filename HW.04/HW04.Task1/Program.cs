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

            Program.SumValues(value1, value2);
        }
    }
}
