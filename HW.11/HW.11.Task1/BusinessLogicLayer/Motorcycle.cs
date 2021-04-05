using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.BusinessLogic
{
    class Motorcycle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Odometer { get; set; }

        public Motorcycle(string brand, string model, int year, int odometer)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Odometer = odometer;
        }
    }
}
