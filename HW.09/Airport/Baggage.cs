using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    class Baggage
    {
        internal double height { get; set; }
        internal double width { get; set; }
        internal double depth { get; set; }
        internal double weight { get; set; }
        internal bool isExceedsStandardSize { get; set; }
        internal bool isRegistered { get; set; }

        internal Baggage(double width, double height, double depth, double weight)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.weight = weight;
        }

        internal static bool IsParameterValid(string inputtedParameter)
        {
            return double.TryParse(inputtedParameter, out double parameter) && parameter>0;
        }
    }
}
