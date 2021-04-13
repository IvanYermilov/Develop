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
            Console.WriteLine("Please, input your address:");
            string name = ClientNameSurnameArray[Constants.nameIndexInArray];
            string surname = ClientNameSurnameArray[Constants.surnameIndexInArray];
            string email = GetValidClientEmail();
            string address = Console.ReadLine();
            Client client = new Client(name, surname, address, email);
            Console.WriteLine("Thank you for your personal information.");
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

        public static Dictionary<string, Sushi> SushiListConvert(List<Sushi> sushiList)
        {
            Dictionary<string, Sushi> sushiListDictionary = new Dictionary<string, Sushi>();
            foreach (Sushi sushi in sushiList)
            {
                sushiListDictionary.Add(sushi.ToString(), sushi);
            }
            return sushiListDictionary;
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
        public static T Menu<T>(Dictionary<string,T> list)
        {
            int a = Console.CursorTop;
            int listIndex = 0;
            int index = 0;
            T value = default;
            for (; ; )
            {
                Console.CursorVisible = false;
                //Console.WriteLine();
                foreach (var item in list)
                {
                    if (listIndex == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        value = item.Value;
                    }
                    Console.WriteLine(item.Key);
                    Console.ResetColor();
                    listIndex++;
                }
                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.DownArrow):
                        listIndex = 0;
                        index++;
                        if (index > list.Count - 1) index = 0;
                        break;
                    case (ConsoleKey.UpArrow):
                        listIndex = 0;
                        index--;
                        if (index < 0) index = list.Count - 1;
                        break;
                    case (ConsoleKey.Enter):
                        return value;
                    _:
                        listIndex = 0;
                        break;
                }
                Console.SetCursorPosition(0, a);
            }
        }
    }
}
