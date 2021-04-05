using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task_1.BusinessLogic;

namespace Task_1
{
    interface IRepository
    {
        public void Create(Motorcycle motorcycle);
        public Motorcycle GetById(int id);
        public ArrayList GetAll();
        public void Update(int id, Motorcycle motorccycle);
        public void Delete(int id);
    }
}
