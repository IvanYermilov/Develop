using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    class Passenger
    {
        internal Passport passport { get; set; }
        internal Ticket ticket { get; set; }
        internal BoardingPass boardingPass { get; set; }
        internal Baggage baggage { get; set; }
    }
}
