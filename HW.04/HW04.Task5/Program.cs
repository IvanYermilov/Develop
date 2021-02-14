using System;

namespace HW04.Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("English alphabet in reverse order: ");
            for (char symbol='z'; symbol >= 'a'; symbol--)  
            {
                Console.Write(symbol+" ");
            }
        }
    }
}
