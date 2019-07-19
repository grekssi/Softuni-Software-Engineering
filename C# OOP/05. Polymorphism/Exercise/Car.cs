using System;

namespace Vehicle
{
    public class Car : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;

        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set { this.fuelConsumption = value + 0.9; }
        }


        public string Drive(double distance)
        {
            double total = this.fuelQuantity - distance * fuelConsumption;
            if (total < 0)
            {
                return $"Car needs refueling";
            }
            else if (total == 0)
            {
                this.fuelQuantity -= distance * fuelConsumption;
                return $"Car travelled {distance} km"
                       + Environment.NewLine
                       + $"Car needs refueling";
            }
            else
            {
                this.fuelQuantity -= distance * fuelConsumption;
                return $"Car travelled {distance} km";
            }
        }

        public void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
