using System;
using System.Threading;

namespace Airport
{
    class RegistrationSystem
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

        internal static void Greeting(Passenger passenger) 
        {
            DateTime minskTime = DateTime.UtcNow.AddHours(Constants.minskTimeZone);
            RegistrationSystem.Wait();
            Console.WriteLine($"\nHello! {passenger.passport.name}, you have arrived to the National Airport Minsk. Now is {minskTime} Minsk time.");
        }

        internal static Passenger GetPersonalInfo()
        {
            Console.Write("\nHello! Before we will start our journey, please, input first and last name separated by space symbol(\" \"): ");
            string[] PassangerNameSurnameArray;
            for (; ; )
            {
                string PassangerNameSurname = Console.ReadLine();
                PassangerNameSurnameArray = PassangerNameSurname.Split(' ');
                if (PassangerNameSurnameArray.Length >= Constants.passengerNameSurnamePartialsNumber &&
                        PassangerNameSurnameArray[Constants.nameIndexInArray] != String.Empty && 
                        PassangerNameSurnameArray[Constants.surnameIndexInArray] != String.Empty) break;
                Console.WriteLine("Something went wrong. Please, input your name and surname separately again.");
            }

            string name = PassangerNameSurnameArray[0];
            string surname = PassangerNameSurnameArray[1];
            Passenger passenger = new Passenger();
            passenger.passport = new Passport(name, surname);
            return passenger;
        }
        
        internal static bool IsPersonalHasTicket(Passenger passenger)
        {
            Console.WriteLine($"Great! {passenger.passport.name}, first of all, please, answer the question: do you have a flight ticket?\n" +
                "Answer \"yes\" if you have one and \"no\" if you haven't.");
            for (; ; )
                {
                string answer = Console.ReadLine();
                switch (answer)
                    {
                        case string str when str.Equals(Constants.positiveAnswer):
                            return true;
                        case string str when str.Equals(Constants.negativeAnswer):
                            Console.WriteLine("That's not really nice :( Go back when you get some ticket.");
                            return false;
                        default:
                            Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                            break;
                    }
                }
        }

        internal static void GetTicketInfo(Passenger passenger)
        {
            string ticketBookingNumber;
            string ticketFlightNumber;
            DateTime ticketDepartureDate;
            Console.WriteLine($"{passenger.passport.name}, cool! If you have a ticket we need to know a little about it.\n" +
                $"Please, input ticket's booking number:");
            for (; ; )
            {
                string inputtedTicketBookingNumber = Console.ReadLine();
                if (Ticket.IsBookingNunmberValid(inputtedTicketBookingNumber))
                {
                    ticketBookingNumber = inputtedTicketBookingNumber;
                    break;
                }
                Console.WriteLine("Hmm... Doesn't look like booking number. Just a reminder booking number is a six upper case symbol number.");
            }
            Console.WriteLine($"Well, now input ticket's flight number, please:");
            for (; ; )
            {
                string inputtedTicketFlightNumber = Console.ReadLine();
                if (Ticket.IsflightNumberValid(inputtedTicketFlightNumber))
                {
                    ticketFlightNumber = inputtedTicketFlightNumber;
                    break;
                }
                Console.WriteLine("Hmm... Doesn't look like flight number. Just a reminder booking number is a four-digit number.");
            }
            Console.WriteLine($"Well, now input ticket's departure date in format dd.mm.yyyy, please:");
            for (; ; )
            {
                string inputtedTicketDepartureDate = Console.ReadLine();
                if (DateTime.TryParse(inputtedTicketDepartureDate, out DateTime parsedDepartureDate))
                {
                    ticketDepartureDate = parsedDepartureDate;
                    break;
                }
                Console.WriteLine("Hmm... Guess there is a problem with format, try again.");
            }
            passenger.ticket = new Ticket(ticketBookingNumber, ticketFlightNumber, ticketDepartureDate);
            Console.WriteLine("Thank you for getting ticket's info!");
        }

        internal static void OnlineCheckIn(Passenger passenger)
        {
            string surname;
            int planeSeatNumber;
            bool isPrinted = false;
            Console.WriteLine("You will arrive to the airport soon. Just wait a little.\n" +
                "Do you want to Check In online before? Answer \"yes\" if you want and \"no\" if you are not.");
            for (; ; )
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        {
                            Console.WriteLine($"Ok, {passenger.passport.name}. First of all we need to check your booking number:");
                            RegistrationSystem.CheckBookingNumber(passenger);
                            Console.WriteLine($"Well, now input your Surname:");
                            surname = RegistrationSystem.GetValidPassengerSurname(passenger);
                            passenger.passport.seriesNumber = RegistrationSystem.GetValidPassportSeriesNumber();
                            planeSeatNumber = RegistrationSystem.GetValidSeatNumber(passenger);
                            passenger.boardingPass = new BoardingPass(isPrinted, planeSeatNumber, passenger.passport.name, surname);
                            Console.WriteLine("You have cheked in successfully!");
                            return;
                        } 
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Ok, as you wish :)");
                        return;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
        }

        internal static void ChooseCheckInType(Passenger passenger)
        {
            for (; ; )
            {
                Console.WriteLine("Now you need to check-in. Do you want to do it via check-in desk or check-in machine.\n" +
                "Type \"desk\" or \"machine\" depending on the choice:");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.deskCheckInAnswer):
                        {
                            RegistrationSystem.DescCheckIn(passenger);
                            if (passenger.boardingPass != null) return;
                            break;
                        }
                    case string str when str.Equals(Constants.machineCheckInAnswer):
                        {
                            RegistrationSystem.MachineCheckIn(passenger);
                            if (passenger.boardingPass != null) return;
                            break;
                        }
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"desk\" or \"machine\". Try again!");
                        break;
                }
            }
        }

        internal static void DescCheckIn(Passenger passenger)
        {
            string surname;
            int planeSeatNumber;
            bool isPrinted = true;
            Console.WriteLine("Do you really want to check-in via desk.\n" +
                "Answer \"yes\" if you want and \"no\" if you are not.");
            for (; ; )
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        {
                            Console.WriteLine($"Ok, {passenger.passport.name}. Go to the check-in desk." +
                                "\nWelcome to the National Airport Minsk check-in desk. As far as we know you have a ticket " +
                                "so to registrate and print boarding pass we need to know your surname and passport series/number only." +
                                "\nInput your Surname, please:");
                            surname = RegistrationSystem.GetValidPassengerSurname(passenger);
                            passenger.passport.seriesNumber = RegistrationSystem.GetValidPassportSeriesNumber();
                            planeSeatNumber = RegistrationSystem.GetValidSeatNumber(passenger);
                            passenger.boardingPass = new BoardingPass(isPrinted, planeSeatNumber, passenger.passport.name, surname);
                            Console.WriteLine("You have cheked in successfully!");
                            Console.WriteLine("Boarding pass is printing. Wait, please.");
                            RegistrationSystem.Wait();
                            Console.WriteLine("Boarding pass has been printed.");
                            return;
                        }
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Ok, as you wish :)");
                        return;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
        }

        internal static void MachineCheckIn(Passenger passenger)
        {
            string surname;
            int planeSeatNumber;
            bool isPrinted = true;
            Console.WriteLine("Do you really want to check-in via machie.\n" +
                "Answer \"yes\" if you want and \"no\" if you are not.");
            for (; ; )
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        {
                            Console.WriteLine($"You went to the check-in machine.\n" +
                                $"Ok, {passenger.passport.name}. First of all you need to input your booking number:");
                            RegistrationSystem.CheckBookingNumber(passenger);
                            Console.WriteLine($"Well, now input your Surname:");
                            surname = RegistrationSystem.GetValidPassengerSurname(passenger);
                            passenger.passport.seriesNumber = RegistrationSystem.GetValidPassportSeriesNumber();
                            planeSeatNumber = RegistrationSystem.GetValidSeatNumber(passenger);
                            passenger.boardingPass = new BoardingPass(isPrinted, planeSeatNumber, passenger.passport.name, surname);
                            Console.WriteLine("You have cheked in successfully!");
                            Console.WriteLine("Boarding pass is printing. Wait, please.");
                            RegistrationSystem.Wait();
                            Console.WriteLine("Boarding pass has been printed.");
                            return;
                        }
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Ok, as you wish :)");
                        return;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
        }

        internal static void BoardingPassPrinting(Passenger passenger)
        {
            Console.WriteLine("\nYou've got boarding pass already, cool. Go to the check-in desk to print it." +
                "\nWelcome to the National Airport Minsk check-in desk. Input your surname that we printed boarding pass:");
            for (; ; )
            {
                string inputtedSurname = Console.ReadLine();
                if (RegistrationSystem.IsInputtedSurnameValid(inputtedSurname, passenger))
                {
                    passenger.boardingPass.isPrinted = true;
                    Console.WriteLine("Boarding pass is printing. Wait, please.");
                    RegistrationSystem.Wait();
                    Console.WriteLine("Boarding pass has been printed.");
                    return;
                }
                Console.WriteLine("Unfortunately we can't find flight with you on board. Perhaps you made a mistake. Input your surname again.");
            }

        }

        internal static bool IsTodayDepartureDate(DateTime ticketDepartureDate)
        {
            DateTime today = DateTime.Now;
            if (ticketDepartureDate.Year == today.Year && ticketDepartureDate.Month == today.Month
                && ticketDepartureDate.Day == today.Day) return true;
            if (ticketDepartureDate.Year > today.Year || ticketDepartureDate.Month > today.Month
                || ticketDepartureDate.Day > today.Day)
            {
                Console.WriteLine("Your plane won't departure today. Come back later.");
                return false;
            }
            else
            {
                Console.WriteLine("\nUnfortunately you are late. Your plane has already departed.");
                return false;
            }
        }

        internal static string GetValidPassengerSurname(Passenger passenger)
        {
            for (; ; )
            {
                string inputtedSurname = Console.ReadLine();
                if (RegistrationSystem.IsInputtedSurnameValid(inputtedSurname, passenger)) return inputtedSurname;
                Console.WriteLine("Surname you inputted doesn't belongs to you. Try again.");
            }
        }        

        internal static bool IsInputtedSurnameValid(string inputtedSurname, Passenger passenger)
        {
            return inputtedSurname == passenger.passport.surname;
        }

        internal static string GetValidPassportSeriesNumber()
        {
            Console.WriteLine($"Input your passport series and number:");
            for (; ; )
            {
                string inputtedPassportSeriesNumber = Console.ReadLine();
                if (Passport.IsSeriesNumberValid(inputtedPassportSeriesNumber)) return inputtedPassportSeriesNumber;
                Console.WriteLine("Hmm... Guess there is a problem with format. " +
                    "Just a reminder passport series and number has format \"AB1234567\", try again.");
            }
        }

        internal static void CheckBookingNumber(Passenger passenger)
        {
            for (; ; )
            {
                string inputtedBookingNumber = Console.ReadLine();
                if (Ticket.IsBookingNunmberValid(inputtedBookingNumber) &&
                    inputtedBookingNumber == passenger.ticket.bookingNumber) break;
                Console.WriteLine("Hmm... Doesn't look like booking number. Just a reminder booking " +
                    "number is a six upper case symbol number. Or booking number you inutted isn't yours :). Try again.");
            }
        }

        internal static int GetValidSeatNumber(Passenger passenger)
        {
            Console.WriteLine($"Flight #{passenger.ticket.flightNumber} has {Constants.planeSeatsNumber} seats. Input seat number" +
                $" where you want to sit:");
            for (; ; )
            {
                string inputtedSeatNumber = Console.ReadLine();
                if (int.TryParse(inputtedSeatNumber, out int seatNumber) && seatNumber > 0 && seatNumber <= Constants.planeSeatsNumber)
                return seatNumber;
                Console.WriteLine("Hmm... Guess there is a problem with format or there is no such seat number in the plane, try again.");
            }
        }

        internal static void BaggageRegistry(Baggage baggage)
        {
            Console.WriteLine("Because of your baggage exceeds standard baggage size you must register and put it on the baggage carousel. " +
                "Let's go to the Check-in desk.\n" +
                "Glad to see you at Check-in desk. Do you want to register your baggage? Answer \"yes\" if you want and \"no\" if you don't");
            string answer = string.Empty;
            while (answer != Constants.positiveAnswer)
            {
                answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        Console.WriteLine("Wait a second, please.");
                        RegistrationSystem.Wait();
                        baggage.isRegistered = true;
                        Console.WriteLine("Your baggage was successfully registered.");
                        break;
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Think twice. You won't pass preflight inspection if you don't register your baggage.\n" +
                            "So, do you want to register your baggage?");
                        break;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
            answer = string.Empty;
            Console.WriteLine("Great! Now you should put baggage on carusel. Do you want to do it? Answer \"yes\" if you want and \"no\" if you don't");
            while (answer != Constants.positiveAnswer)
            {
                answer = Console.ReadLine();
                switch (answer)
                {
                    case string str when str.Equals(Constants.positiveAnswer):
                        Console.WriteLine("You put your baggage on carusel and it moves slowly away.");
                        break;
                    case string str when str.Equals(Constants.negativeAnswer):
                        Console.WriteLine("Think twice. You won't pass preflight inspection if you don't leave your baggage on the carusel.\n" +
                            "So, do you want to put your baggage on the carusel?");
                        break;
                    default:
                        Console.WriteLine("Looks like you inputted something that doesn't looks like \"yes\" or \"no\". Try again!");
                        break;
                }
            }
            Console.WriteLine("Cool! You could go to the Border Monitoring now.");
        }
    }
}
