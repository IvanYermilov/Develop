using Serilog;
using System;
using Task_1.BusinessLogic;
using Task_1.DataAccessLayer;
using System.Collections;

namespace Task_1.UserInterface
{
    class ConsoleIO
    {
        public IRepository Repository { get; set; }

        public ConsoleIO()
        {
            Repository = new MotorcycleRepository();
        }

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            Repository.Create(motorcycle);
        }

        public void GetMotorcycleById(int id)
        {
            Motorcycle motorcycle = Repository.GetById(id);
            if (motorcycle != null)
            {
                Log.Information($"Motorcycle displaying process has been started.");
                PrintMotorcycle(motorcycle);
            }
            else Console.WriteLine($"Tnere is no motorcycle with id = {id}");
        }

        public void GetAllMotorcycles()
        {
            ArrayList motorcycleList = Repository.GetAll();
            if (motorcycleList != null)
            {
                Log.Information($"Motorcycles displaying process has been started.");
                foreach (Motorcycle motorcycle in motorcycleList)
                {
                    PrintMotorcycle(motorcycle);
                }
            }
            else Console.WriteLine("There is nothing to display");
        }

        public void UpadateMotorcycle(int id, Motorcycle motorcycle)
        {
            Repository.Update(id, motorcycle);
        }

        public void DeleteMotorcycle(int id)
        {
            Repository.Delete(id);
        }

        public void PickOperation(out bool isProgramMustStop)
        {
            int motorcycleId;
            isProgramMustStop = false;
            Console.Write("Input one of five operation you can do with data in database " +
                "(create; readAll, readById, update, delete)\nor input \"exit\" if you want to stop the program:");
            for (; ; )
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case ("create"):
                        CreateMotorcycle(GetMotorcycle());
                        return;
                    case ("readAll"):
                        GetAllMotorcycles();
                        return;
                    case ("readById"):
                        Console.Write("Input ID of motorcycle you want to read: ");
                        motorcycleId = GetMotorcycleId();
                        GetMotorcycleById(motorcycleId);
                        return;
                    case ("update"):
                        Console.Write("Input ID of motorcycle you want to upadte: ");
                        motorcycleId = GetMotorcycleId();
                        Console.WriteLine($"Input new information about motorcycle with ID-{motorcycleId}");
                        UpadateMotorcycle(motorcycleId, GetMotorcycle());
                        return;
                    case ("delete"):
                        Console.Write("Input ID of motorcycle you want to delete: ");
                        motorcycleId = GetMotorcycleId();
                        DeleteMotorcycle(motorcycleId);
                        return;
                    case ("exit"):
                        isProgramMustStop = true;
                        return;
                    default:
                        Console.Write("Program cannot perform this operation. Try to input operation again:");
                        break;
                }
            }
        }

        public Motorcycle GetMotorcycle()
        {
            Console.Write("Input motorcycle Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Input motorcycle Model: ");
            string model = Console.ReadLine();
            int year = GetMotorcycleYear();
            int odometer = GetMotorcycleOdometer();
            return new Motorcycle(brand, model, year, odometer);
        }

        public static void PrintMotorcycle(Motorcycle motorcycle)
        {
            Console.WriteLine($"Motorcycle info - ID:{motorcycle.Id}, Brand:{motorcycle.Brand}, Model:{motorcycle.Model}, " +
                $"Year made:{motorcycle.Year}, Odometer value:{motorcycle.Odometer}");
        }

        public static int GetMotorcycleId()
        {
            for (; ; )
            {
                string motorcycleIdStr = Console.ReadLine();
                if (int.TryParse(motorcycleIdStr, out int motorcycleId)) return motorcycleId;
                Console.Write("Programm cannot parse inputted data. Try again: ");
            }
        }

        public static int GetMotorcycleYear()
        {
            for (; ; )
            {
                Console.Write("Input motorcycle year made: ");
                string motorcycleYearMadeStr = Console.ReadLine();
                if (int.TryParse(motorcycleYearMadeStr, out int motorcycleYearMade)) return motorcycleYearMade;
                Console.WriteLine("Programm cannot parse inputted data. Try again: ");
            }
        }
        public static int GetMotorcycleOdometer()
        {
            for (; ; )
            {
                Console.Write("Input odometer value: ");
                string motorcycleOdometerStr = Console.ReadLine();
                if (int.TryParse(motorcycleOdometerStr, out int motorcycleOdometer)) return motorcycleOdometer;
                Console.WriteLine("Programm cannot parse inputted data. Try again: ");
            }
        }

    }
}
