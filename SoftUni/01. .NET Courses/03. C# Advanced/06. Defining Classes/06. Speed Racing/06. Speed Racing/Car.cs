using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double traveledDistance = 0;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }


        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }

        public double TraveledDistance
        {
            get { return this.traveledDistance; }
            set { this.traveledDistance = value; }
        }

        public Car(string name, double fuelAmount, double fuelConsumption)
        {
            this.model = name;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumption;
        }

        public void Drive(int distance)
        {
            if (this.fuelAmount - fuelConsumptionPerKilometer * distance >= 0)
            {
                this.fuelAmount -= fuelConsumptionPerKilometer * distance;
                this.traveledDistance += distance;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
