using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Transactions;

namespace Vehicle
{
    public class Bus : VehicleAbstract
    {
        private const double ACconsumption = 1.4;
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption) 
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public string DriveFull(double distance)
        {
            base.FuelConsumption += 1.4;
            string toReturn = this.Drive(distance);
            base.FuelConsumption -= 1.4;
            return toReturn;
        }

        public override string Drive(double distance)
        {
            double total = this.FuelQuantity - distance * FuelConsumption;
            if (total < 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= distance * FuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }

        public override void Refuel(double liters)
        {
            if (base.FuelConsumption + liters > base.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            this.FuelConsumption += liters;
        }
    }
}
