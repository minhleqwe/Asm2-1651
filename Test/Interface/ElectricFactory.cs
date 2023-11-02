using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Interface
{
    public class ElectricFactory : IVehicleFactory
    {
        public AbstractCar CreateCar()
        {
            return new ElectricCar();
        }

        public AbstractShip CreateShip()
        {
            return new ElectricShip();
        }
    }
}
