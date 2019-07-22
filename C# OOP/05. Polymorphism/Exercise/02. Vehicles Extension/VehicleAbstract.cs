using System;

namespace Vehicle
{
    public abstract class VehicleAbstract
    {
        private double tankCapacity;
        private double fuelConsumption;
        private double fuelQuantity;

        protected double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        protected double FuelConsumption
        {
            get => this.fuelConsumption;
            set { this.fuelConsumption = value; }
        }

        protected double TankCapacity
        {
            get => this.tankCapacity;
            set
            {
                if (value < 0)
                {
                    throw  new ArgumentException("Fuel must be a positive number");
                }
                this.tankCapacity = value;
            }
        }
    

        public VehicleAbstract(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        public abstract string Drive(double distance);

        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
