using System;

namespace HW._02.Types
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte a1 = 1;
            Console.WriteLine(a1.GetType());
            SByte a2 = 2;
            Console.WriteLine(a2.GetType());

            short b1 = 3;
            Console.WriteLine(b1.GetType());
            Int16 b2 = 4;
            Console.WriteLine(b2.GetType());

            int c1 = 5;
            Console.WriteLine(c1.GetType());
            Int32 c2 = 6;
            Console.WriteLine(c2.GetType());

            long d1 = 7;
            Console.WriteLine(d1.GetType());
            Int64 d2 = 8;
            Console.WriteLine(d2.GetType());

            byte e1 = 9;
            Console.WriteLine(e1.GetType());
            Byte e2 = 10;
            Console.WriteLine(e2.GetType());

            ushort f1 = 11;
            Console.WriteLine(f1.GetType());
            UInt16 f2 = 12;
            Console.WriteLine(f2.GetType());

            char g1 = 'a';
            Console.WriteLine(g1.GetType());
            Char g2 = 'b';
            Console.WriteLine(g2.GetType());

            uint h1 = 13;
            Console.WriteLine(h1.GetType());
            UInt32 h2 = 14;
            Console.WriteLine(h2.GetType());

            ulong i1 = 15;
            Console.WriteLine(i1.GetType());
            UInt64 i2 = 16;
            Console.WriteLine(i2.GetType());

            float j1 = 17;
            Console.WriteLine(j1.GetType());
            Single j2 = 18;
            Console.WriteLine(j2.GetType());

            double k1 = 19;
            Console.WriteLine(k1.GetType());
            Double k2 = 20;
            Console.WriteLine(k2.GetType());

            decimal l1 = 21;
            Console.WriteLine(l1.GetType());
            Decimal l2 = 22;
            Console.WriteLine(l2.GetType());

            object m1 = new object();
            Console.WriteLine(m1.GetType());
            Object m2 = new Object();
            Console.WriteLine(m2.GetType());

            string n1 = "23";
            Console.WriteLine(n1.GetType());
            String n2 = "24";
            Console.WriteLine(n2.GetType());
        }
    }
}
