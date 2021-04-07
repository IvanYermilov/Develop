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
            throw new NotImplementedException();
        }

        public Sushi GetById(int id)
        {
            throw new NotImplementedException();
        }

        //public ArrayList GetAll()
        //{
        //    if (IsValuesInDb())
        //    {
        //        ArrayList motorcycleList = storage.motorcycleList;
        //        Log.Information($"All motorcycles exist in database were retrieved.");
        //        return motorcycleList;
        //    }
        //    else Log.Information("Database is empty.");
        //    return null;
        //}

        //public Motorcycle GetById(int id)
        //{
        //    Motorcycle motorcycle = null;
        //    foreach (var motoObj in storage.motorcycleList)
        //    {
        //        motorcycle = (Motorcycle)motoObj;
        //        if (motorcycle.Id == id)
        //        {
        //            Log.Information($"Motorcycle with ID={motorcycle.Id} was retrieved.");
        //            return motorcycle;
        //        }
        //        else motorcycle = null;
        //    }
        //    Log.Information($"There is no motorcycle with ID={id} in database.");
        //    return motorcycle;
        //}

        //public bool IsValuesInDb()
        //{
        //    return storage.motorcycleList.Count != 0;
        //}
        internal void LogTesting()
        {
            Log.Info("KeK");
        }
    }
}
