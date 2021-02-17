using System;

namespace HW._05.Task2
{
    class Program
    {
        public static int TakeLastDigit(int number)
        {
            if (number < 10) return number;
            return number % 10;
        }

        static void Main(string[] args)
        {
            int number;

            for (; ;)
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

            for (int i = 1, j = number; i <= number; i++, j--)
            {
                for (int n = 1, m = 1; m <= j; n++)
                {
                    if (n < i) Console.Write(" ");
                    else
                    {
                        Console.Write(Program.TakeLastDigit(i) + " ");
                        m++;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}