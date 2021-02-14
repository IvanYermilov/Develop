using System;

namespace HW04.Task4
{
    class Program
    {
        static void CheckResult(int value1, int value2, char operationChar, int supposedResult)
        {
            int result = 0;
            switch (operationChar)
            {
                case '+':
                    result = value1 + value2;
                    break;
                case '-':
                    result = value1 - value2;
                    break;
            }
            if (result == supposedResult) Console.WriteLine("You're right!");
            else if (result < supposedResult) Console.WriteLine("You made a mistake. The result is lower.");
            else if (result > supposedResult) Console.WriteLine("You made a mistake. The result is greater.");
        }

        static void Main(string[] args)
        {
            Console.Write("Input the first integer value you want to make operation with: ");
            string value1Str = Console.ReadLine();
            if (!int.TryParse(value1Str, out int value1))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }

            Console.Write("Input the second integer value you want to make operation with: ");
            string value2Str = Console.ReadLine();
            if (!int.TryParse(value2Str, out int value2))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }

            Console.Write("Enter the mathematical operation (+ or -) you want to do with values: ");
            char operationChar = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (operationChar != '-' && operationChar != '+')
            {
                Console.WriteLine("You inputted incorrect operator.");
                return;
            }

            Console.Write($"Input supposed result (integer value) of operation \"({value1}) {operationChar} ({value2})\": ");
            string supposedResultStr = Console.ReadLine();
            if (!int.TryParse(supposedResultStr, out int supposedResult))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }

            Program.CheckResult(value1, value2, operationChar, supposedResult);
        }
    }
}
