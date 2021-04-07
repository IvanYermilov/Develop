using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    interface IRepository
    {
        Sushi GetById(int id);
        List<Sushi> GetAll();
    }
}
