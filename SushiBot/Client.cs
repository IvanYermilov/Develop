using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SushiBot
{
    class Client
    {
        private string _name;
        private string _surname;
        private string _address;
        private string _email;

        public string Name
        {
            get { return _name; }
        }
        public string Surname
        {
            get { return _surname; }
        }
        public string Address
        {
            get { return _address; }
        }
        public string Email
        {
            get { return _email; }
        }

        public Client(string name, string surname, string address, string email)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _email = email;
        }

        internal static bool IsEmailValid(string clientEmail)
        {
            string pattern = @"^[0-9a-z.\-_]+@[a-z]+\.[a-z]+$";
            Regex rgx = new Regex(pattern,RegexOptions.IgnoreCase);
            return rgx.IsMatch(clientEmail);
        }
    }
}
