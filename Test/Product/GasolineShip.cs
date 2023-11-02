using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class GasolineShip : AbstractShip
    {
        public override string ToString()
        {
            return Fuel + Name;
        }
        public override double speedup(double firstspeed, double secondspeed)
        {
            double acceleration = Acceleration;

            return Math.Abs(((firstspeed - secondspeed) * 52) / acceleration);
        }

        public override double reducespeed(double firstspeed, double secondspeed)
        {
            double acceleration = Acceleration;

            return Math.Abs(((firstspeed - secondspeed) * 47) / acceleration);
        }
        public override double downstream(double firstSpeed, double enginecapacity)
        {
            double time = (100 * 15 * enginecapacity) / (enginecapacity * (firstSpeed - 10) * 0.01);
            return Math.Abs(time);
        }
        public override double upstream(double firstSpeed, double enginecapacity)
        {
            double time = (100 * 15 * enginecapacity) / (enginecapacity * (firstSpeed + 10) * 0.01);
            return Math.Abs(time);
        }
    }
}
