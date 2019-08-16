using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Tire3
    {
        private double tire3Pressure;
        private int tire3Age;
        public Tire3(double tire3Pressure, int tire3Age)
        {
            this.tire3Pressure = tire3Pressure;
            this.tire3Age = tire3Age;
        }
        public double Tire3Pressure
        {
            get { return this.tire3Pressure; }
            set { this.tire3Pressure = value; }
        }

        public int Tire3Age
        {
            get { return this.tire3Age; }
            set { this.tire3Age = value; }
        }
    }
}
