using System;

namespace HW06.Task1
{
    class Program
    {
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

        static int[] ArraySum(int[] array1, int[] array2)
        {
            int[] resultArray = new int[array1.Length];
            Console.WriteLine("Arrays's elements summing in process");
            for (int i = 0; i < array1.Length; i++)
            {
                resultArray[i] = array1[i] + array2[i];
                Console.WriteLine(".");
            }
            Console.WriteLine("Arrays's elements summing was finished!");
            return resultArray;
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

        static void Main(string[] args)
        {
            int[] array1 = new int[5];
            int[] array2 = new int[5];
            int[] resultArray;
            Random random = new Random();

            Console.WriteLine("Array #1 filling in process");
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = random.Next(100);
                Console.WriteLine(".");
            }
            Console.WriteLine("Array #1 filling was finished!");
            Program.ArrayShow(array1, nameof(array1));

            Console.WriteLine("Array #2 filling");
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = Program.GetValueForArray();
            }
            Program.ArrayShow(array2, nameof(array2));

            resultArray = Program.ArraySum(array1, array2);
            Program.ArrayShow(resultArray, nameof(resultArray));
        }
    }
}