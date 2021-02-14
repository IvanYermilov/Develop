using System;

namespace HW04.Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            int value2;
            string str1 = "65";
            int.TryParse(str1, out int value1);
            value2 = int.Parse(str1);
        }
    }
}
