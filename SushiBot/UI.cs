using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SushiBot
{
    class UI
    {
        internal static void Wait()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.Write(". ");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }

        internal static bool IsProgramStart()
        {
            Console.Write("Input any symbol if you want to stat SushiBOT." +
                "\nInput \"q\" if you want to stop the program:");
            for (; ; )
            {
                char userInput = Console.ReadKey().KeyChar;
                switch (userInput)
                {
                    case ('q'):
                        return false;
                    default:
                        Console.Write("\nOk, bot is starting");
                        Wait();
                        return true;
                }
            }
        }

        internal static Client GetClientlInfo()
        {
            Console.WriteLine("Please, input your name and surname separated by space symbol(\" \"): ");
            string[] ClientNameSurnameArray;
            for (; ; )
            {
                try
                {
                    string ClientNameSurname = Console.ReadLine();
                    ClientNameSurnameArray = ClientNameSurname.Split(' ');
                    if (ClientNameSurnameArray.Length <= Constants.clientNameSurnamePartialsNumber &&
                            ClientNameSurnameArray[Constants.nameIndexInArray] != string.Empty &&
                            ClientNameSurnameArray[Constants.surnameIndexInArray] != string.Empty) break;
                    Console.WriteLine("Something went wrong. Please, input your name and surname separately again.");

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Something went wrong. Please, input your name and surname separately again.");
                    continue;
                }
            }
            string name = ClientNameSurnameArray[Constants.nameIndexInArray];
            string surname = ClientNameSurnameArray[Constants.surnameIndexInArray];
            string email = GetValidClientEmail();
            Client client = new Client(name,surname,email);
            return client;
        }

        private static string GetValidClientEmail()
        {
            Console.WriteLine($"Input your Email:");
            for (; ; )
            {
                string inputtedClientEmail = Console.ReadLine();
                if (Client.IsEmailValid(inputtedClientEmail)) return inputtedClientEmail;
                Console.WriteLine("Hmm... Guess there is a problem with format. " +
                    "Just a reminder email has the format \"example@example.example\", try again.");
            }
        }

        //public void PickOperation(out bool isProgramMustStop)
        //{
        //    int motorcycleId;
        //    isProgramMustStop = false;
        //    Console.Write("Input one of five operation you can do with data in database " +
        //        "(create; readAll, readById, update, delete)\nor input \"exit\" if you want to stop the program:");
        //    for (; ; )
        //    {
        //        string userInput = Console.ReadLine();
        //        switch (userInput)
        //        {
        //            case ("create"):
        //                CreateMotorcycle(GetMotorcycle());
        //                return;
        //            case ("readAll"):
        //                GetAllMotorcycles();
        //                return;
        //            case ("readById"):
        //                Console.Write("Input ID of motorcycle you want to read: ");
        //                motorcycleId = GetMotorcycleId();
        //                GetMotorcycleById(motorcycleId);
        //                return;
        //            case ("update"):
        //                Console.Write("Input ID of motorcycle you want to upadte: ");
        //                motorcycleId = GetMotorcycleId();
        //                Console.WriteLine($"Input new information about motorcycle with ID-{motorcycleId}");
        //                UpadateMotorcycle(motorcycleId, GetMotorcycle());
        //                return;
        //            case ("delete"):
        //                Console.Write("Input ID of motorcycle you want to delete: ");
        //                motorcycleId = GetMotorcycleId();
        //                DeleteMotorcycle(motorcycleId);
        //                return;
        //            case ("exit"):
        //                isProgramMustStop = true;
        //                return;
        //            default:
        //                Console.Write("Program cannot perform this operation. Try to input operation again:");
        //                break;
        //        }
        //    }
        //}
        public static string Menu()
        {
            int a = Console.CursorTop;
            int index = 0;
            string[] strArr = { Constants.PostitiveAnswer, Constants.NegativeAnswer };
            for (; ; )
            {
                Console.CursorVisible = false;
                //Console.WriteLine();
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;

                    }
                    Console.WriteLine(strArr[i]);
                    Console.ResetColor();
                }
                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.DownArrow):
                        index++;
                        if (index > strArr.Length - 1) index = 0;
                        break;
                    case (ConsoleKey.UpArrow):
                        index--;
                        if (index < 0) index = strArr.Length - 1;
                        break;
                    case (ConsoleKey.Enter):
                        return strArr[index];
                }
                Console.SetCursorPosition(0, a);
            }
        }
    }
}
