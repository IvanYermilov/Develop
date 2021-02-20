using System;

namespace HW06.Task3
{
    class Program
    {
        static int valueStorage;
        static int GetValueForArray()
        {
            for (; ; )
            {
                Console.Write("Input the value you want insert into array cell: ");
                string value = Console.ReadLine();
                if (int.TryParse(value, out int parsedResult)) return parsedResult;
                Console.WriteLine("Programm cannot parse inputted data.");
            }
        }

        static void ArrayShow(int[] array, string arrayName)
        {
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Element[{i}] in {arrayName} is: {array[i]}");
            }
            Console.WriteLine();
        }

        static void FillUpArray(int[] array)
        {
            Console.WriteLine("Array filling in process");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Program.GetValueForArray();
            }
            Console.WriteLine("Array filling was finished!");
        }

        static void ReverseArray(int[] array)
        {
            int arrayLastIndex = array.Length - 1;
            for (int i = 0; i < array.Length / 2; i++)
            {
                valueStorage = array[arrayLastIndex - i];
                array[arrayLastIndex - i] = array[i];
                array[i] = valueStorage;
            }
        }

        static void Main(string[] args)
        {
            int[] array = new int[5];
            Program.FillUpArray(array);
            Program.ArrayShow(array, nameof(array));
            Program.ReverseArray(array);
            Program.ArrayShow(array, nameof(array));
        }
    }
}
