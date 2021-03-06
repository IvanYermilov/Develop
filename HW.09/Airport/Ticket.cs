using System;
using System.Text.RegularExpressions;

namespace Airport
{
    class Ticket
    {
        internal readonly string bookingNumber;
        internal readonly string flightNumber;
        internal readonly DateTime departureDate;

        internal Ticket(string bookingNumber, string flightNumber, DateTime departureDate)
        {
            this.bookingNumber = bookingNumber;
            this.flightNumber = flightNumber;
            this.departureDate = departureDate;
        }

        internal static bool IsBookingNunmberValid(string checkedBookingNumber)
        {
            string pattern = $"^[A-Z]{{{Constants.bookingNumberLength}}}$";
            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(checkedBookingNumber);
        }

        internal static bool IsflightNumberValid(string checkedFlightNumber)
        {
            if (int.TryParse(checkedFlightNumber, out int plug)) return checkedFlightNumber.Length == Constants.flightNumberLength;
            return false;
        }
    }
}
