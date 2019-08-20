using System;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles.Models
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;
        private const double InitializeCubicCentimeters = 450;
        private const double MinimalHorsePower = 70;
        private const double MaximumHorsePower = 100;
        public PowerMotorcycle(string model, int horsePower)
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
