using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    class BoardingPass
    {
        internal bool isPrinted { get; set; }
        internal int seatNumber { get; set; }
        internal string passengerName { get; set; }
        internal string passengerSurname { get; set; }

        internal BoardingPass(bool isPrinted, int seatNumber, string passengerName, string passengerSurname)
        {
            this.isPrinted = isPrinted;
            this.seatNumber = seatNumber;
            this.passengerName = passengerName;
            this.passengerSurname = passengerSurname;
        }
    }
}
