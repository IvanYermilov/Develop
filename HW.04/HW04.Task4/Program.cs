using System;

namespace HW04.Task4
{
    class Program
    {
        static bool IsResultTrue(int value1, int value2, char operationChar, int supposedResult)
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
            if (result == supposedResult)
            {
                Console.WriteLine("You're right!");
                return true;
            }
            else if (result < supposedResult)
            {
                Console.WriteLine("You made a mistake. The result is lower.");
                return false;
            }
            else
            {
                Console.WriteLine("You made a mistake. The result is greater.");
                return false;
            }
        }

        static void Main(string[] args)
        {
            int value1, value2, supposedResult;
            char operationChar;
            for (; ; )
            {
                Console.Write("Input the first integer value you want to make operation with: ");
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
                Console.Write("Input the second integer value you want to make operation with: ");
                string value2Str = Console.ReadLine();
                if (int.TryParse(value2Str, out int parsedResult2))
                {
                    value2 = parsedResult2;
                    break;
                }
                Console.WriteLine("Programm cannot parse inputted data.");
            }

            for (; ; )
            {
                Console.Write("Enter the mathematical operation (+ or -) you want to do with values: ");
                char parsedOperationChar = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (parsedOperationChar != '-' && parsedOperationChar != '+') Console.WriteLine("You inputted incorrect operator.");
                else 
                {
                    operationChar = parsedOperationChar;
                    break;
                }

            }

            for (; ; )
            {
                Console.Write($"Input supposed result (integer value) of operation \"({value1}) {operationChar} ({value2})\": ");
                string supposedResultStr = Console.ReadLine();
                if (int.TryParse(supposedResultStr, out int parsedSupposedResult))
                {
                    supposedResult = parsedSupposedResult;
                    if (Program.IsResultTrue(value1, value2, operationChar, supposedResult)) break;
                }
                else Console.WriteLine("Programm cannot parse inputted data.");
            }
        }
    }
}
