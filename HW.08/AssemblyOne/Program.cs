using System;

namespace AssemblyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Motorcycle moto = new Motorcycle();
            moto.publicModel = 15;
            SportBike sportBike = new SportBike();
            //int model = sportBike.protectedModel; can't get value because it available in basic and derived classes only.
            //moto.privateMmodel = 20; can't set value because it available in Motorcycle class only.
            moto.StartEngine();
            sportBike.StartEngine();
            moto.StopEngine();
            sportBike.StopEngine();
            //moto.vin = 40; can't set value because it available in Motorcycle and SportBike classes only (in spite of Program class
            //declared in AssemblyOne).
        }
    }
}
