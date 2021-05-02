using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using SushiBot.Estensions;

namespace SushiBot
{
    static class UI
    {
        public static event Action NotifyCustomer; 
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
            Console.Write("Input any symbol if you want to start SushiBOT." +
                "\nInput \"q\" if you want to stop the program: ");
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

        internal static void ShowMenu(ProductRepository productRep)
        {
            Console.WriteLine("\nLook at sushi menu:\n" +
                              "------------------");
            foreach (var sushi in productRep.GetAll())
            {
                Console.WriteLine(sushi.ToString());
            }
            Console.WriteLine("------------------\n");
        }
        internal static void ShowCart(CartRepository cartRepository)
        {
            Console.WriteLine("\nYour current Cart:\n" +
                              "------------------");
            foreach (var position in cartRepository.GetAll())
            {
                Console.WriteLine(CartPosition2String(position));
            }
            Console.Write("------------------\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Total price: ");
            Console.ResetColor();
            Console.WriteLine(cartRepository.Cart.GetCurrentCartPrice());
        }  
        
        internal static string ConvertCart2String(CartRepository cartRepository)
        {
            string result = "------------------<br>";
            foreach (var position in cartRepository.GetAll())
            {
                result += $"{CartPosition2String(position)}<br>";
            }
            result += "------------------<br>";
            return result += $"<b>Total price:</b> {cartRepository.Cart.GetCurrentCartPrice()}";
        }

        

        internal static void Order(ProductRepository productRep, CartRepository cartRep)
        {
            for (; ; )
            {
                Console.WriteLine("Pick up operation:");
                string userInput = Menu(ArrayConvert(Constants.MainMenu));
                switch (userInput)
                {
                    case (Constants.MenuOptionAdd):
                        Console.WriteLine("Choose sushi you want to add to Cart:");
                        Sushi sushi = Menu(SushiListConvert(productRep.GetAll()));
                        Console.Write("Input amount of sushi you want to add to Cart: ");
                        uint sushiAmount = GetPositiveNumber();
                        cartRep.Add(sushi, sushiAmount);
                        break;
                    case (Constants.MenuOptionChange):
                        var cartList = cartRep.GetAll();
                        if (cartList != null)
                        {
                            Console.WriteLine("Choose position in Cart you want to change amount:");
                            var cartPosition = Menu(CartListConvert(cartList));
                            Console.Write("Input amount of sushi you want to set in Cart position: ");
                            sushiAmount = GetPositiveNumber();
                            cartRep.EditValue(cartPosition, sushiAmount);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Cart is Empty.");
                            Console.ResetColor();
                        }
                        break;
                    case (Constants.MenuOptionDelete):
                        cartList = cartRep.GetAll();
                        if (cartList != null)
                        {
                            Console.WriteLine("Choose position in Cart you want to delete:");
                            var cartPosition = Menu(CartListConvert(cartList));
                            cartRep.Cart.ProductList.Remove(cartPosition.Key);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Cart is Empty.");
                            Console.ResetColor();
                        }
                        break;
                    case (Constants.MenuOptionShow):
                        cartList = cartRep.GetAll();
                        if (cartList != null) ShowCart(cartRep);
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Cart is Empty.");
                            Console.ResetColor();
                        }
                        break;
                    case (Constants.MenuOptionConfirm):
                        cartList = cartRep.GetAll();
                        if (cartList != null) return;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Your Order is Empty. There is nothing to confirm.");
                            Console.ResetColor();
                            break;
                        }
                }
                Console.WriteLine();
            }
        }

        internal static Client GetClientlInfo()
        {
            Console.WriteLine("Please, input your name and surname separated by space symbol(\" \"): ");
            string[] clientNameSurnameArray;
            for (; ; )
            {
                try
                {
                    string clientNameSurname = Console.ReadLine();
                    clientNameSurnameArray = clientNameSurname.Split(' ');
                    if (clientNameSurnameArray.Length <= Constants.ClientNameSurnamePartialsNumber &&
                            clientNameSurnameArray[Constants.NameIndexInArray] != string.Empty &&
                            clientNameSurnameArray[Constants.SurnameIndexInArray] != string.Empty) break;
                    Console.WriteLine("Something went wrong. Please, input your name and surname separately again.");

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Something went wrong. Please, input your name and surname separately again.");
                }
            }
            
            string name = clientNameSurnameArray[Constants.NameIndexInArray];
            string surname = clientNameSurnameArray[Constants.SurnameIndexInArray];
            Console.WriteLine($"{name}, please, input your Email:");
            string email = GetValidClientEmail();
            Console.WriteLine($"{name}, please, input your address:");
            string address = Console.ReadLine();
            Client client = new Client(name, surname, address, email);
            Console.WriteLine($"{client.Name} thank you for your personal information.");
            return client;
        }

        private static string GetValidClientEmail()
        {
            for (; ; )
            {
                string inputtedClientEmail = Console.ReadLine();
                if (inputtedClientEmail.IsEmailValid()) return inputtedClientEmail;
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

        public static Dictionary<string, KeyValuePair<Sushi, uint>> CartListConvert(Dictionary<Sushi, uint> cartList)
        {
            Dictionary<string, KeyValuePair<Sushi, uint>> cartiListDictionary = new Dictionary<string, KeyValuePair<Sushi, uint>>();
            foreach (var cartProduct in cartList)
            {
                cartiListDictionary.Add(CartPosition2String(cartProduct), cartProduct);
            }
            return cartiListDictionary;
        }

        public static Dictionary<string, string> ArrayConvert(string[] answerList)
        {
            Dictionary<string, string> answerDictionary = new Dictionary<string, string>();
            foreach (var answer in answerList)
            {
                answerDictionary.Add(answer, answer);
            }
            return answerDictionary;
        }

        public static string CartPosition2String(KeyValuePair<Sushi, uint> cartPosition)
        {
            return $"{cartPosition.Key.ToString()}. Amount: {cartPosition.Value}";
        }

        public static T Menu<T>(Dictionary<string,T> list)
        {
            int a = Console.CursorTop;
            int listIndex = 0;
            int index = 0;
            T value = default;
            for (; ; )
            {
                Console.CursorVisible = false;
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
                        Console.WriteLine();
                        return value;
                }
                Console.SetCursorPosition(0, a);
            }
        }

        public static uint GetPositiveNumber()

        {
            for (; ; )
            {
                string numberStr = Console.ReadLine();
                if (uint.TryParse(numberStr, out uint number)) return number;
                Console.Write("Program cannot parse inputted data. Try again: ");
            }
        }

        public static bool ConfirmOrder(CartRepository cartRep)
        {
            bool isOrderConfirmed = default;
            ShowCart(cartRep);
            Console.WriteLine("\nDo you confirm your order?");
            string userInput = Menu(ArrayConvert(Constants.YesNoMenu));
            switch (userInput)
            {
                case (Constants.PositiveAnswer):
                    isOrderConfirmed = true;
                    break;
                case (Constants.NegativeAnswer):
                    isOrderConfirmed = false;
                    break;
            }
            return isOrderConfirmed;
        }

        public static void SendNotification()
        {
            NotifyCustomer.Invoke();
        }
    }
}
