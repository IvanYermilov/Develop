using System;

namespace HW._05.Task1
{
    class Program
    {
        static int GetSum(int value)
        {
            int sum = 0;
            for (int i = 1; i <= value; i++)
            {
                sum += i; 
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int number;
            for (; ; )
            {
                Console.Write("Input positive number: ");
                string strNumber = Console.ReadLine();
                if (!int.TryParse(strNumber, out int parsedValue)) Console.WriteLine("Programm cannot parse inputted data. \n");
                else
                {
                    number = Math.Abs(parsedValue);
                    Console.WriteLine();
                    break;
                }

            }

            Console.Write($"The result of summing is: {Program.GetSum(number)}");
        }
    }
}
