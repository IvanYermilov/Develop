using System.Text.RegularExpressions;

namespace SushiBot.Estensions
{
    static class StringExtension
    {
        public static bool IsEmailValid(this string clientEmail)
        {
            string pattern = @"^[0-9a-z.\-_]+@[a-z]+\.[a-z]+$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            return rgx.IsMatch(clientEmail);
        }
    }
}
