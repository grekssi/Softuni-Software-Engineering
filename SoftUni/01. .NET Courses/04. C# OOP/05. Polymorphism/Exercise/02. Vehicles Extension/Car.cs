using System;

namespace Vehicle
{
    public class Car : VehicleAbstract
    {
        private const double ACconsumption = 0.9;
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {

        }

        public override string Drive(double distance)
        {
            double total = base.FuelQuantity - distance * (FuelConsumption + ACconsumption);
            if (total < 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= distance * (FuelConsumption + ACconsumption);
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            base.FuelQuantity += liters;
        }
    }
}
