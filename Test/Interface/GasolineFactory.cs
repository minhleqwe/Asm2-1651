using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Interface
{
    public class GasolineFactory : IVehicleFactory
    {
        public AbstractCar CreateCar()
        {
            return new GasolineCar();
        }

        public AbstractShip CreateShip()
        {
            return new GasolineShip();
        }
    }
}
