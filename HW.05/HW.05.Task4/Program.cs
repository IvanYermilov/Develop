using System;

namespace HW._05.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int counter = 0;
                Console.Write("Input any string: ");
                string word = Console.ReadLine();

                foreach (var character in word)
                {
                    switch (character.Equals(Convert.ToChar(65)) || character.Equals(Convert.ToChar(97)) || character.Equals(Convert.ToChar(1072)) || character.Equals(Convert.ToChar(1040)))
                    {
                        case (true):
                            counter++;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine($"Number of Latin and Cyrillic 'a' (in spite of case) symbols in the inputted word is {counter}");
            }
        }
    }
}