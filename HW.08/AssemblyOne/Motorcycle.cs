using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyOne
{
    public class Motorcycle
    {
        public int publicModel;
        private int privateMmodel{ get; set; }
        protected int protectedModel;
        private protected int vin;

        protected internal void StartEngine() 
        {
        }

        internal void StopEngine()
        {
        }

        public void SetModel() 
        {
            privateMmodel= 15;
        }
    }
}
