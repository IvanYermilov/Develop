using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    static class Constants
    {
        public const string PositiveAnswer = "Yes"; 
        public const string NegativeAnswer = "No";
        public const string MenuOptionAdd = "Add sushi to Cart";
        public const string MenuOptionChange = "Change sushi amount in Cart";
        public const string MenuOptionDelete = "Delete position from Cart";
        public const string MenuOptionShow = "Show Cart";
        public const string MenuOptionConfirm = "Confirm order";
        public static readonly string[] YesNoMenu = { PositiveAnswer, NegativeAnswer };
        public static readonly string[] MainMenu =
        {
            MenuOptionAdd, MenuOptionChange, MenuOptionDelete, MenuOptionShow, MenuOptionConfirm
        };
        internal const int NameIndexInArray = 0;
        internal const int SurnameIndexInArray = 1;
        internal static int ClientNameSurnamePartialsNumber = 2;
    }
}
