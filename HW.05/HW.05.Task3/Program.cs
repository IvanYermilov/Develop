using System;

namespace HW._05.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            switch (currentTime.Hours)
            {
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("Good morning, guys");
                    break;
                case 12:
                case 13:
                case 14:
                    Console.WriteLine("Good day, guys");
                    break;
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    Console.WriteLine("Good evening, guys");
                    break;
                default:
                    Console.WriteLine("Just hello, guys :)");
                    break;
            }
        }
    }
}
