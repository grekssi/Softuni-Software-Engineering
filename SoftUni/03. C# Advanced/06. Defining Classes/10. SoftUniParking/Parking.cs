using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count => this.cars.Count();

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public string AddCar(Car car)
        {
            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return @"Car with that registration number, already exists!";
            }

            else if (cars.Count >= this.capacity)
            {
                return $"Parking is full!";
            }

            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string numberPlate)
        {
            if (cars.All(x => x.RegistrationNumber != numberPlate))
            {
                return $"Car with that registration number, doesn't exist!";
            }

            else
            {
                this.cars.Remove(this.cars.FirstOrDefault(x => x.RegistrationNumber == numberPlate));
                return $"Successfully removed {numberPlate}";
            }
        }

        public Car GetCar(string numberPlate)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == numberPlate);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
            }
        }

    }
}
