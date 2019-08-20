using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < number; i++)
            {
                var inputCar = Console.ReadLine()?.Split(' ').ToArray();
                string model = inputCar[0];
                double fuelAmount = double.Parse(inputCar[1]);
                double fuelConsumption = double.Parse(inputCar[2]);
                var car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToArray();
                if (command[0] == "End")
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
                    }
                    break;
                }

                string carModel = command[1];
                int amountKMs = int.Parse(command[2]);
                Car carToSearchFor = cars.Where(x => x.Model == carModel).FirstOrDefault();
                carToSearchFor.Drive(amountKMs);

            }
        }
    }
}
