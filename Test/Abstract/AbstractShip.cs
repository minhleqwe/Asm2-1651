using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class AbstractShip
    {
        private string name;
        private string fuel;
        private string enginecapacity;
        private double acceleration;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public string Enginecapacity
        {
            get { return enginecapacity; }
            set { enginecapacity = value; }
        }
        public double Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }
        public abstract override string ToString();
        public abstract double speedup(double firstSpeed, double secondSpeed);

        public abstract double reducespeed(double firstSpeed, double secondSpeed);

        public abstract double downstream(double firstSpeed, double enginecapacity);

        public abstract double upstream(double firstSpeed, double enginecapacity);
    }
}
