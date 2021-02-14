using System;

namespace HW03.Birthday
{
    class Program
    {
        static bool IsMonthValid(int month)
        {
            if (month > 0 && month <= 12) return true;

            Console.WriteLine("Month was inputted in the wrong format. Enter number from 1 to 12 included");
            return false;    
        }

        static bool IsYearValid(int year)
        {
            if (year >= 0) return true;

            Console.WriteLine($"Year was inputted in the wrong format. Enter number from 0 to {int.MaxValue} included");
            return false;
        }
        static void Main(string[] args)
        {
            Console.Write("Input the month Person was born: ");
            string birthMonthStr = Console.ReadLine();
            if (!int.TryParse(birthMonthStr, out int birthMonth))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return; 
            }
            if (!Program.IsMonthValid(birthMonth)) return;

            Console.Write("Input the year Person was born: ");
            string birthYearStr = Console.ReadLine();
            if (!int.TryParse(birthYearStr, out int birthYear))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }
            if (!Program.IsYearValid(birthYear)) return;

            Console.Write("Input current month: ");
            string currentMonthStr = Console.ReadLine();
            if (!int.TryParse(currentMonthStr, out int currentMonth))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }
            if (!Program.IsMonthValid(currentMonth)) return;

            Console.Write("Input current year: ");
            string currentYearStr = Console.ReadLine();
            if (!int.TryParse(currentYearStr, out int currentYear))
            {
                Console.WriteLine("Programm cannot parse inputted data.");
                return;
            }
            if (!Program.IsYearValid(currentYear)) return;

            if (currentYear < birthYear | (currentYear == birthYear & currentMonth < birthMonth))
            {
                Console.WriteLine("Person haven't born at that time yet");
                return;
            }
            else
            {
                int personAge = (int)(currentMonth - birthMonth + 12 * (currentYear - birthYear)) / 12;
                Console.WriteLine($"Person was born at {birthMonth}-th month of {birthYear}-th year");
                Console.WriteLine($"Now is {currentMonth}-th month of {currentYear}-th year");
                Console.WriteLine($"Age of person is {personAge} year(-s)");
            }
        }
    }
}