using SushiBot.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class Repository: IRepository
    {
        public Storage storage = new Storage();
        public List<Sushi> GetAll()
        {
            if (IsSushiInSushiList())
            {
                List<Sushi> sushiList = storage.sushiList;
                Log.Info($"All sushies exist in database were retrieved.");
                return sushiList;
            }
            else Log.Info("Database is empty.");
            return null;
        }

        public Sushi GetById(int id)
        {
            Sushi sushi = storage.sushiList.FirstOrDefault(sushiObj => sushiObj.Id == id);
            if (sushi != null) Log.Info($"Sushi with ID={sushi.Id} was retrieved.");
            else Log.Info($"There is no sushi with ID={id} in database.");
            return sushi;
        }

        public bool IsSushiInSushiList()
        {
            return storage.sushiList.Count != 0;
        }
    }
}
