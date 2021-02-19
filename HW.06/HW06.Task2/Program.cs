using System;

namespace HW06.Task2
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
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = Program.GetValueForArray();
            }
            Console.WriteLine("Array filling was finished!");
        }

        static void ArrayInsertValue(int[] array, int value, uint index) 
        {
            uint arraylengthIgnoreLastValue = (uint)array.Length - 1;
            uint transferArrayLength = arraylengthIgnoreLastValue - index;
            int[] transferArray = new int[transferArrayLength];
            Array.Copy(array, index, transferArray, 0, transferArray.Length);
            array[index] = value;
            Array.Copy(transferArray, 0, array, index+1, transferArray.Length);
        }

        static void Main(string[] args)
        {
            int[] array = new int[5];
            int value;
            uint index;
            Program.FillUpArray(array);
            Program.ArrayShow(array, nameof(array));

            for (; ; )
            {
                Console.Write("Input value you want to insert in array: ");
                string value1Str = Console.ReadLine();
                if (int.TryParse(value1Str, out int valueParseResult))
                {
                    value = valueParseResult;
                    break;
                }
                Console.WriteLine("Programm cannot parse inputted data.");
            }

            for (; ; )
            {
                Console.Write($"Input index (index's value must be between 0 and {array.Length-1}) of array where you want to insert value: ");
                string value1Str = Console.ReadLine();
                if (uint.TryParse(value1Str, out uint indexParseResult))
                {
                    index = indexParseResult;
                    if (index <= array.Length - 1) break;
                    Console.WriteLine("Your input is out of required range.");
                }
                else Console.WriteLine("Programm cannot parse inputted data or you inputted negative value.");
            }

            Program.ArrayInsertValue(array, value, index);
            Program.ArrayShow(array, nameof(array));

        }
    }
}
