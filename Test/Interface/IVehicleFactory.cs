using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Interface
{
    public interface IVehicleFactory
    {
        AbstractCar CreateCar();
        AbstractShip CreateShip();
    }
}
