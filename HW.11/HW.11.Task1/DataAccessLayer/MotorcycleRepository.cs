using System.Collections;
using Task_1.BusinessLogic;
using Task_1.Data;
using Serilog;

namespace Task_1.DataAccessLayer
{
    class MotorcycleRepository : IRepository
    {
        Storage storage = new Storage();

        public void Create(Motorcycle motorcycle)
        {
            motorcycle.Id = storage.CurrentId++;
            storage.motorcycleList.Add(motorcycle);
            Log.Information($"Motorcycle with ID={motorcycle.Id} was created.");
        }

        public void Delete(int id)
        {
            Motorcycle motorcycle = null;
            foreach (Motorcycle motoObj in storage.motorcycleList)
            {
                if (motoObj.Id == id) motorcycle = motoObj;
            }
            if (motorcycle != null)
            {
                storage.motorcycleList.Remove(motorcycle);
                Log.Information($"Motorcycle with ID={motorcycle.Id} was removed.");
            }
            else Log.Information($"There is nothing to delete because motorcycle with ID={id} doesn't exist in database.");
        }
        public ArrayList GetAll()
        {
            if (IsValuesInDb())
            {
                ArrayList motorcycleList = storage.motorcycleList;
                Log.Information($"All motorcycles exist in database were retrieved.");
                return motorcycleList;
            } 
            else Log.Information("Database is empty.");
            return null;
        }

        public Motorcycle GetById(int id)
        {
            Motorcycle motorcycle = null;
            foreach (var motoObj in storage.motorcycleList)
            {
                motorcycle = (Motorcycle)motoObj;
                if (motorcycle.Id == id)
                {
                    Log.Information($"Motorcycle with ID={motorcycle.Id} was retrieved.");
                    return motorcycle;
                } 
                else motorcycle = null;
            }
            Log.Information($"There is no motorcycle with ID={id} in database.");
            return motorcycle;
        }

        public void Update(int id, Motorcycle motorcycle)
        {
            bool isMotorcycleFounded=false;
            Motorcycle replacedMotorcycle;
            foreach (Motorcycle motoObj in storage.motorcycleList)
            {
                if (motoObj.Id == id)
                {
                    isMotorcycleFounded = true;
                    replacedMotorcycle = motoObj;
                    replacedMotorcycle.Model = motorcycle.Model;
                    replacedMotorcycle.Brand = motorcycle.Brand;
                    replacedMotorcycle.Year = motorcycle.Year;
                    replacedMotorcycle.Odometer = motorcycle.Odometer;
                    Log.Information($"Motorcycle with ID={replacedMotorcycle.Id} was updated.");
                } 
            }
            if(!isMotorcycleFounded) Log.Information($"There is nothing to update because motorcycle with ID={id} doesn't exist in database.");
        }

        public bool IsValuesInDb()
        {
            return storage.motorcycleList.Count != 0;
        }
    }
}
