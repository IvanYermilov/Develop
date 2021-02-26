using System;
using AssemblyOne;

namespace AssemblyTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Motorcycle moto = new Motorcycle();
            //SportBike sportBike = new SportBike(); can't create instance of SportBike class because it has Internal access modifier
            moto.publicModel = 15;
            //moto.StartEngine(); StartEngine(protected internal method) doesn't accessible because of class Program doesn't derived 
            //                    from Motorcycle and because of class Program doesn't basic class where method declared
            //moto.StopEngine(); StartEngine(internal method) doesn't accessible because of it declared in AssemblyOne(Motorcycle class)
            //moto.vin = 40; can't set value because it available in Motorcycle and SportBike classes only that declared in AssemblyOne.
        }
    }
}
