using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot.Exceptions
{
    internal class CartLimitExceededException:Exception
    {
        public CartLimitExceededException()
        {
        }

        public CartLimitExceededException(string message) : base(string.Format(message))
        {

        }
    }
}
