using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Tire
    {
        /// <summary>
        /// tyre pressure/age
        /// </summary>
        public Dictionary<double, int> Tyre1 { get; private set; }
        public Dictionary<double, int> Tyre2 { get; private set; }
        public Dictionary<double, int> Tyre3 { get; private set; }
        public Dictionary<double, int> Tyre4 { get; private set; }
        public double minPressure = int.MaxValue;


        public Tire(double tyre1Pressure, int tyre1Age, double tyre2Pressure, int tyre2Age,
            double tyre3Pressure, int tyre3Age, double tyre4Pressure, int tyre4Age)
        {
            if (tyre1Pressure < 1)
            {
                minPressure = tyre1Pressure;
            }

            if (tyre2Pressure < 1)
            {
                minPressure = tyre2Pressure;
            }

            if (tyre3Pressure < 1)
            {
                minPressure = tyre3Pressure;
            }

            if (tyre4Pressure < 1)
            {
                minPressure = tyre4Pressure;
            }

            this.Tyre1 = new Dictionary<double, int>();
            this.Tyre1.Add(tyre1Pressure, tyre1Age);

            this.Tyre2 = new Dictionary<double, int>();
            this.Tyre2.Add(tyre2Pressure, tyre2Age);

            this.Tyre3 = new Dictionary<double, int>();
            this.Tyre3.Add(tyre3Pressure, tyre3Age);

            this.Tyre4 = new Dictionary<double, int>();
            this.Tyre4.Add(tyre4Pressure, tyre4Age);
        }
    }
}
