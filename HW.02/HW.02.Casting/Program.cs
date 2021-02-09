using System;

namespace HW._02.Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Implicit convertation
            byte a1 = 15;
            short a2 = 3;
            a2 = a1;

            short b1 = 18;
            int b2 = 20;
            b2 = b1;

            float c1 = 25;
            long c2 = 33;
            c1 = c2;

            //Explicit convertation
            uint d1 = 33;
            ulong d2 = 18;
            d1 = (uint)d2;

            int e1 = 64;
            double e2 = 13.5;
            e1 = (int)e2;

            sbyte f1 = -6;
            decimal f2 = 31;
            f1 = (sbyte)f2;

            //boxing
            int a = 1;
            Object obj1 = a;
            double b = 13.9;
            Object obj2 = b;
            long c = 1987;
            Object obj3 = c;

            //unboxing
            int d;
            double e;
            long f;
            d = (int)obj1;
            e = (double)obj2;
            f = (long)obj3;
        }
    }
}
