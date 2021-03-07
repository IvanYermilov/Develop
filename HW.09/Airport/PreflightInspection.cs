using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    internal static class PreflightInspection
    {
        internal static bool IsPassengerHasBaggage(Passenger passenger)
        {
            Console.WriteLine($"Now it's time for preflight inspection. {passenger.passport.name}, do you have a baggage?\n" +
                "Answer \"yes\" if you have and \"no\" if you haven't");
            for (; ; )
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        return true;
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Ok, that's means you could go to the Border Monitoring.");
                        return false;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
        }

        internal static void GetBaggageInfo(Passenger passenger)
        {
            Console.WriteLine($"Well tell us your baggage parameters.");
            Console.WriteLine("Please, input your baggage width:");
            double width = PreflightInspection.GetBaggageParameter();
            Console.WriteLine("Please, input your baggage height:");
            double height = PreflightInspection.GetBaggageParameter();
            Console.WriteLine("Please, input your baggage depth:");
            double depth = PreflightInspection.GetBaggageParameter();
            Console.WriteLine("Please, input your baggage weight");
            double weight = PreflightInspection.GetBaggageParameter();
            passenger.baggage = new Baggage(width, height, depth, weight);
            Console.WriteLine("Thank you!");
        }

        internal static void BaggageChecking(Baggage baggage)
        {
            Console.WriteLine("Let's chack your baggage parameters.");
            if (baggage.width > Constants.standardWidth) 
            {
                Console.WriteLine($"Your baggage width is {baggage.width}cm and it exceeds standard baggage width {Constants.standardWidth}cm");
                baggage.isExceedsStandardSize = true;
            }
            if (baggage.height > Constants.standardHeight)
            {
                Console.WriteLine($"Your baggage height is {baggage.height}cm and it exceeds standard baggage height {Constants.standardHeight}cm");
                if (baggage.isExceedsStandardSize != true) baggage.isExceedsStandardSize = true;
            }
            if (baggage.depth > Constants.standardDepth)
            {
                Console.WriteLine($"Your baggage depth is {baggage.depth}cm and it exceeds standard baggage depth {Constants.standardDepth}cm");
                if (baggage.isExceedsStandardSize != true) baggage.isExceedsStandardSize = true;
            }
            if (baggage.weight > Constants.standardWeight)
            {
                Console.WriteLine($"Your baggage weight is {baggage.weight}kg and it exceeds standard baggage weight {Constants.standardWeight}kg");
                if (baggage.isExceedsStandardSize != true) baggage.isExceedsStandardSize = true;
            }
            if (!baggage.isExceedsStandardSize)
            {
                RegistrationSystem.Wait();
                Console.WriteLine("Great! Your baggage doesn't exceed standard baggage size " +
                  "that's means you could go to the Border Monitoring without baggage registration.");
            }
        }

        internal static double GetBaggageParameter()
        {
            for (; ; )
            {
                string inputtedParameter = Console.ReadLine();
                if (Baggage.IsParameterValid(inputtedParameter)) return double.Parse(inputtedParameter);
                Console.WriteLine("Cannot convert your input. Try again.");
            }
        }
    }
}
