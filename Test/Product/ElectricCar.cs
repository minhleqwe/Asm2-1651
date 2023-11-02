using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    public class ElectricCar : AbstractCar
    {
        public override string ToString()
        {
            return Fuel + Name;
        }
        public override double speedup(double firstspeed, double secondspeed)
        {
            double acceleration = Acceleration;

            return Math.Abs(((firstspeed - secondspeed) * 40) / acceleration);
        }

        public override double reducespeed(double firstspeed, double secondspeed)
        {
            double acceleration = Acceleration;

            return Math.Abs(((firstspeed - secondspeed) * 35) / acceleration);
        }
        public override double move(double firstSpeed, double enginecapacity)
        {
            double time = (100 * enginecapacity * 9 * 0.95) / (enginecapacity * 0.01 * firstSpeed);
            return Math.Abs(time);
        }

    }
}
