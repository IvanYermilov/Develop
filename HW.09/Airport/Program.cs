using System;

namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            Passenger passenger;
            passenger = RegistrationSystem.GetPersonalInfo();
            if (!RegistrationSystem.IsPersonalHasTicket(passenger)) return;
            RegistrationSystem.GetTicketInfo(passenger);
            if (!RegistrationSystem.IsTodayDepartureDate(passenger.ticket.departureDate)) return;
            RegistrationSystem.OnlineCheckIn(passenger);
            RegistrationSystem.Greeting(passenger);
            if (passenger.boardingPass != null && passenger.boardingPass.isPrinted == false) RegistrationSystem.BoardingPassPrinting(passenger);
            if (passenger.boardingPass == null) RegistrationSystem.ChooseCheckInType(passenger);
            if (PreflightInspection.IsPassengerHasBaggage(passenger))
            {
                PreflightInspection.GetBaggageInfo(passenger);
                PreflightInspection.BaggageChecking(passenger.baggage);
                if (passenger.baggage.isExceedsStandardSize) RegistrationSystem.BaggageRegistry(passenger.baggage);
            }
            BorderMonitoring.DocumentsChecking(passenger);
        }
    }
}
