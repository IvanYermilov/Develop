﻿using System;

namespace HW03.Calculator.Static
{
    static class Calculator
    {
        public static double Sum(double value1, double value2)
        {
            double sumResult = value1 + value2;
            return sumResult;
        }
        public static double Subtract(double value1, double value2)
        {
            double subResult = value1 - value2;
            return subResult;
        }
        public static double Multiply(double value1, double value2)
        {
            double mulResult = value1 * value2;
            return mulResult;
        }
        public static double Divide(double value1, double value2)
        {
            double divResult = value1 / value2;
            return divResult;
        }
        public static double Reminder(double value1, double value2)
        {
            double remResult = value1 % value2;
            return remResult;
        }
        public static double circleSquare(double radius)
        {
            double circSquare = Math.PI * Math.Pow(radius, 2);
            return circSquare;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double value1;
            double value2;
            double radius;
            Console.Write("Input the First number will be summed with the Second one: ");
            string str1 = Console.ReadLine();
            if (double.TryParse(str1, out value1));
            else
            {
                Console.WriteLine("Number was inputted in the wrong format");
                return;
            }
            Console.Write("Input the Second number will be summed with the First one: ");
            string str2 = Console.ReadLine();
            if (double.TryParse(str2, out value2));
            else
            {
                Console.WriteLine("Number was inputted in the wrong format");
                return;
            }
            Console.WriteLine($"First number + Second number = {Calculator.Sum(value1, value2)}");
            Console.WriteLine();

            Console.Write("Input the First number from wich will be substracted the Second one: ");
            str1 = Console.ReadLine();
            value1 = double.Parse(str1);
            Console.Write("Input the Second number will be substracted from the First one: ");
            str2 = Console.ReadLine();
            value2 = double.Parse(str2);
            Console.WriteLine($"First number - Second number = {Calculator.Subtract(value1, value2)}");
            Console.WriteLine();

            Console.Write("Input the First number will be multiplied by the Second one: ");
            str1 = Console.ReadLine();
            value1 = double.Parse(str1);
            Console.Write("Input the Second number will be multiplied by the First one: ");
            str2 = Console.ReadLine();
            value2 = double.Parse(str2);
            Console.WriteLine($"First number * Second number = {Calculator.Multiply(value1, value2)}");
            Console.WriteLine();

            Console.Write("Input the First number will be divided into the Second one: ");
            str1 = Console.ReadLine();
            value1 = double.Parse(str1);
            Console.Write("Input the Second number on wich the First one will be divided: ");
            str2 = Console.ReadLine();
            value2 = double.Parse(str2);
            if (value2 == 0) Console.WriteLine("Division by zero is prohibited!");
            else Console.WriteLine($"First number / Second number = {Calculator.Divide(value1, value2)}");
            Console.WriteLine();

            Console.Write("Input the First number will be divided into the Second one to calculate Remainder: ");
            str1 = Console.ReadLine();
            value1 = Convert.ToDouble(str1);
            Console.Write("Input the Second number on wich the First one will be divided to calculate Remainder: ");
            str2 = Console.ReadLine();
            value2 = Convert.ToDouble(str2);
            if (value2 == 0) Console.WriteLine("Division by zero is prohibited!");
            else Console.WriteLine($"Remainder of the division of First number and Second number = {Calculator.Reminder(value1, value2)}");
            Console.WriteLine();

            Console.Write("Input the Radius of the circle: ");
            str1 = Console.ReadLine();
            radius = Convert.ToDouble(str1);
            Console.WriteLine($"Square of the circle with the Radius was inputted = {Calculator.circleSquare(radius)}");
            Console.ReadKey();
        }
    }
}