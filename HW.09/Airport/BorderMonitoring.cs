using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    class BorderMonitoring
    {
        internal static void DocumentsChecking(Passenger passenger)
        {
            Console.WriteLine($"Welcome to the board monitor. Let's check your documents. Give us your passport, please.\n" +
                $"Do you want to hand over yout pasport? Answer \"yes\" if you want and \"no\" if you doesn't");
            string answer = string.Empty;
            while (answer != Constants.positiveAnswer)
            {
                answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        Console.WriteLine($"Well, your passport data is:\n----------\nCitizen name: {passenger.passport.name}\n" +
                            $"Citizen surname: {passenger.passport.surname}\n" +
                            $"Passport Series&Number: {passenger.passport.seriesNumber}\n" +
                            $"----------\nWe are checking, wait a second, please.");
                        RegistrationSystem.Wait();
                        Console.WriteLine("Everything is OK.");
                        break;
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Think twice. We will not pass you throgh Border if you don't let us chect your passport.\n" +
                            "So, do you want to hand over your passport?");
                        break;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
            Console.WriteLine($"Now give us your boarding pass, please.\n" +
                $"Do you want to hand over yout boarding pass? Answer \"yes\" if you want and \"no\" if you doesn't");
            answer = string.Empty;
            while (answer != Constants.positiveAnswer)
            {
                answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        Console.WriteLine($"Well, your boarding pass data is:\n----------\nPasseger name: {passenger.boardingPass.passengerName}\n" +
                            $"Passenger surname: {passenger.boardingPass.passengerSurname}\n" +
                            $"Passenger seat number: {passenger.boardingPass.seatNumber}\n" +
                            $"----------\nWe are checking, wait a second, please.");
                        RegistrationSystem.Wait();
                        Console.WriteLine("Everything is OK.");
                        break;
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Think twice. We will not pass you throgh Border if you don't let us chect your boarding pass.\n" +
                            "So, do you want to hand over your boarding pass?");
                        break;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
            if (passenger.baggage.isRegistered) Console.WriteLine("Your baggage was got by sorting center and will be handed over to the plane soon.");
            Console.WriteLine($"Your documents are good. So you could go to the Gate leads to the flight #{passenger.ticket.flightNumber}.\n" +
                $"Have a good trip!");
        }
    }
}
