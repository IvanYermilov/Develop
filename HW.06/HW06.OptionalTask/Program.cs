using System;
using System.Diagnostics;

namespace HW06.OptionalTask
{
    class Program
    {
        static void ReverseArray(int[] array)
        {
            int arrayLastIndex = array.Length - 1;
            for (int i = 0; i < array.Length / 2; i++)
            {
                int valueStorage = array[arrayLastIndex - i];
                array[arrayLastIndex - i] = array[i];
                array[i] = valueStorage;
            }
        }

        static void FillUpArray(int[] array) 
        {
            Console.WriteLine("Array filling in process");
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }
            Console.WriteLine("Array filling was finished!");
        }

        static void Main(string[] args)
        {
            int[] array = new int[100_000_000];
            Stopwatch timer = new Stopwatch();

            Program.FillUpArray(array);

            timer.Start();
            Program.ReverseArray(array);
            timer.Stop();
            Console.WriteLine($"Time required for array reversing by user method is: {timer.Elapsed}");

            timer.Reset();

            timer.Start();
            Array.Reverse(array);
            timer.Stop();
            Console.WriteLine($"Time required for array reversing by library method is: {timer.Elapsed}");
        }
    }
}
