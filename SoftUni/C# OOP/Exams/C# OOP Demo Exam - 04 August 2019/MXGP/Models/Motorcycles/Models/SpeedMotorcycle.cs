using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles.Models
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double InitializeCubicCentimeters = 125;
        private const double MinimalHorsePower = 50;
        private const double MaximumHorsePower = 69;
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitializeCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MinimalHorsePower || value > MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
