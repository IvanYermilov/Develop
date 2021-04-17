﻿using Newtonsoft.Json;
using SushiBot.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SushiBot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (UI.IsProgramStart())
            {
                Log.Configuration = new LoggerConfiguration(@"c:\Temp\", LoggerLevels.Info, 30);
                bool isOrderConfirmed = default;
                Order order = default;
                ProductRepository productRep = new ProductRepository();
                CartRepository cartRep = new CartRepository();
                Client client = UI.GetClientlInfo();
                UI.ShowMenu(productRep);
                while (!isOrderConfirmed)
                {
                    UI.Order(productRep, cartRep);
                    isOrderConfirmed = UI.ConfirmOrder(cartRep);
                    order = new Order(cartRep);
                }
                Notifications notifications = new Notifications(client, order);
                UI.SendNotification(notifications.OrderReady2Delivery);
                UI.SendNotification(notifications.OrderDelivered);
                UI.SendNotification(notifications.OrderPaid);
                Console.WriteLine("Good boy");
            }
            //Console.ReadKey();
        }
    }
}
