using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Airport
{
    class Passport
    {
        internal string name { get; set; }
        internal string surname { get; set; }
        internal string seriesNumber { get; set; }

        internal Passport(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        internal static bool IsSeriesNumberValid(string serialNumber)
        {
            string pattern = $"^[A-Z]{{{Constants.passportSeriesLength}}}[0-9]{{{Constants.passportNumberLength}}}$";
            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(serialNumber);
        }

    }
}
