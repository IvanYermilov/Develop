using System;

namespace HW._07.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Input string in one line with ';' separators: ");
            string inputtedString = Console.ReadLine();
            inputtedString = inputtedString.Replace('О', 'А');
            string[] linesArray = inputtedString.Split(';');
            Console.WriteLine("\n\tSplitted string:\n");
            foreach (string line in linesArray)
            {
                Console.WriteLine("\t"+line);
            }
        }
    }
}
