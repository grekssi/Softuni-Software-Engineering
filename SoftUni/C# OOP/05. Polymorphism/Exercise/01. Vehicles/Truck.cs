using System;

namespace Vehicle
{
    public class Truck : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption + 1.6;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set { this.fuelConsumption = value; }
        }

        public string Drive(double distance)
        {
            double total = this.fuelQuantity - distance * fuelConsumption;
            if (total < 0)
            {
                return $"Truck needs refueling";
            }
            else if (total == 0)
            {
                this.fuelQuantity -= distance * fuelConsumption;
                return $"Truck travelled {distance} km" 
                       + Environment.NewLine
                       + $"Truck needs refueling";
            }
            else
            {
                this.fuelQuantity -= distance * fuelConsumption;
                return $"Truck travelled {distance} km";
            }
        }

        public void Refuel(double liters)
        {
            this.fuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
