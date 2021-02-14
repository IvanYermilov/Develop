using System;

namespace HW04.Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ;)
            {
                Console.Write("Input symbol on your keyboard (Press Q to quit): ");
                char Char = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (Char == 'Q')
                {
                    Console.WriteLine("Thanks for playing :)");
                    return;
                }
                else
                {
                    switch (Char)
                    {
                        case 'w':
                            Console.WriteLine($"Сharacter is moving forward.");
                            break;
                        case 'a':
                            Console.WriteLine($"Сharacter is moving left.");
                            break;
                        case 's':
                            Console.WriteLine($"Сharacter is moving back.");
                            break;
                        case 'd':
                            Console.WriteLine($"Сharacter is moving right.");
                            break;
                        default:
                            Console.WriteLine("Сharacter doesn't move.");
                            break;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
