using System;
using System.Text;

namespace HW._08.Task1
{
    class Program
    {
        static void a(string line)
        {
            StringBuilder sb = new StringBuilder(line);
            bool isQuestionMarkFounded = false;
            for (int i = 0; i < sb.Length; i++)
            {
                if (!isQuestionMarkFounded)
                {
                    switch (sb[i])
                    {
                        case char symbol when symbol.Equals('!') || symbol.Equals('.'):
                            sb.Remove(i, 1);
                            i--;
                            break;
                        case char symbol when symbol.Equals('?'):
                            isQuestionMarkFounded = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (sb[i])
                    {
                        case char symbol when symbol.Equals(' '):
                            sb.Replace(sb[i],'_');
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine($"Inputted string w/o '!' and '.' symbols and replaced ' ': {sb.ToString()}");
        }

        static void Main(string[] args)
        {
            Console.Write($"Input string: ");
            string inputtedString = Console.ReadLine();
            Program.a(inputtedString);
        }
    }
}
