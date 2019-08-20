using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Tire4
    {
        private double tire4Pressure;
        private int tire4Age;
        public Tire4(double tire4Pressure, int tire4Age)
        {
            this.tire4Pressure = tire4Pressure;
            this.tire4Age = tire4Age;
        }
        public double Tire4Pressure
        {
            get { return this.tire4Pressure; }
            set { this.tire4Pressure = value; }
        }

        public int Tire4Age
        {
            get { return this.tire4Age; }
            set { this.tire4Age = value; }
        }
    }
}
