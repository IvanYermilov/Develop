using SushiBot.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class ProductRepository: IProductRepository
    {
        public Storage Storage = new Storage();
        public List<Sushi> GetAll()
        {
            if (IsSushiInSushiList())
            {
                List<Sushi> sushiList = Storage.SushiList;
                Log.Info($"All sushies exist in database were retrieved.");
                return sushiList;
            }
            else Log.Info("Database is empty.");
            return null;
        }

        public Sushi GetById(int id)
        {
            Sushi sushi = Storage.SushiList.FirstOrDefault(sushiObj => sushiObj.Id == id);
            if (sushi != null) Log.Info($"Sushi with ID={sushi.Id} was retrieved.");
            else Log.Info($"There is no sushi with ID={id} in database.");
            return sushi;
        }

        public bool IsSushiInSushiList()
        {
            return Storage.SushiList.Count != 0;
        }
    }
}
