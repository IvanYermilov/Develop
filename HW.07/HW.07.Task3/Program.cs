using System;

namespace HW._07.Task3
{
    class Program
    {
        static double ParseStringValue(string valueStr)
        {
            if (double.TryParse(valueStr, out double parsedResult)) return parsedResult;
            else return 0;
        }

        static double ResultCalculate(double value1, double value2, char operationChar)
        {
            switch (operationChar)
            {
                case '+':
                    return value1 + value2;
                    break;
                case '-':
                    return value1 - value2;
                    break;
                case '*':
                    return value1 * value2;
                    break;
                case '/':
                    if (value2 != 0) return value1 / value2;
                    else
                    {
                        Console.WriteLine("You cannot divide by 0");
                        return 0;
                    }
                default:
                    return 0;
            }
        }

        static void lineParse(string line)
        {
            string firstValueStr = String.Empty, secondValueStr = String.Empty;
            char operationSymbol = ' ';
            bool isFirstValueRetrieved = false;
            foreach (var character in line)
            {
                switch (character)
                {
                    case char symbol when symbol >= '0' && symbol <= '9':
                        if (!isFirstValueRetrieved) firstValueStr += symbol;
                        else secondValueStr += symbol;
                        break;
                    case '+':
                        isFirstValueRetrieved = true;
                        operationSymbol = '+';
                        break;
                    case '-':
                        isFirstValueRetrieved = true;
                        operationSymbol = '-';
                        break;
                    case '/':
                        isFirstValueRetrieved = true;
                        operationSymbol = '/';
                        break;
                    case '*':
                        isFirstValueRetrieved = true;
                        operationSymbol = '*';
                        break;
                }
            }
            double firstValue = Program.ParseStringValue(firstValueStr);
            double secondValue = Program.ParseStringValue(secondValueStr);
            Console.WriteLine($"\n{firstValue} {operationSymbol} {secondValue} = {Program.ResultCalculate(firstValue, secondValue, operationSymbol)}");
        }

        static void Main(string[] args)
        {
            Console.Write($"Input string: ");
            string inputtedString = Console.ReadLine();
            Program.lineParse(inputtedString);
        }
    }
}