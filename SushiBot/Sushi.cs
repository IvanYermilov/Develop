using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class Sushi
    {
        private int _id;
        private string _name;
        private decimal _price;
        private string _description;

        public int Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
        }
        public decimal Price
        {
            get { return _price; }
        }

        public string Description
        {
            get { return _description; }
        }

        public Sushi(int id, string name, decimal price, string description)
        {
            _id = id;
            _name = name;
            _price = price;
            _description = description;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Price: {Price}; Description: {Description}";
        }
    }
}
