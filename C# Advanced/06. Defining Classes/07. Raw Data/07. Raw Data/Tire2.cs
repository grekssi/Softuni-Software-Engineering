using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Tire2
    {
        private double tire2Pressure;
        private int tire2Age;
        public Tire2(double tire2Pressure, int tire2Age)
        {
            this.tire2Pressure = tire2Pressure;
            this.tire2Age = tire2Age;
        }
        public double Tire2Pressure
        {
            get { return this.tire2Pressure; }
            set { this.tire2Pressure = value; }
        }

        public int Tire2Age
        {
            get { return this.tire2Age; }
            set { this.tire2Age = value; }
        }
    }
}
