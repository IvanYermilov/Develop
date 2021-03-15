using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyOne
{
    class SportBike:Motorcycle
    {
        public static void GetProtectedModel() 
        {
            SportBike sportBike = new SportBike();
            int model = sportBike.protectedModel;
        }
    }
}
