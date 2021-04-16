using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    interface ICartRepository
    {
        void Add(Sushi sushi, uint quantity);

        void EditValue(KeyValuePair<Sushi, uint> cartPosition, uint sushiAmount);
    }
}
