using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Tire1
    {
        private double tire1Pressure;
        private int tire1Age;

        public Tire1(double tire1Pressure, int tire1Age)
        {
            this.tire1Pressure = tire1Pressure;
            this.tire1Age = tire1Age;
        }
        public double Tire1Pressure
        {
            get { return this.tire1Pressure; }
            set { this.tire1Pressure = value; }
        }

        public int Tire1Age
        {
            get { return this.tire1Age; }
            set { this.tire1Age = value; }
        }
    }
}
