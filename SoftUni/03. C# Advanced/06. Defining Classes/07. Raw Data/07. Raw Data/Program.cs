using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                var newCar = Console.ReadLine().Split(' ').ToArray();
                string model = newCar[0];
                int engineSpeed = int.Parse(newCar[1]);
                int enginePower = int.Parse(newCar[2]);
                int cargoWeight = int.Parse(newCar[3]);
                string cargoType = newCar[4];

                double tire1Pressure = double.Parse(newCar[5]);
                int tire1Age = int.Parse(newCar[6]);

                double tire2Pressure = double.Parse(newCar[7]);
                int tire2Age = int.Parse(newCar[8]);

                double tire3Pressure = double.Parse(newCar[9]);
                int tire3Age = int.Parse(newCar[10]);

                double tire4Pressure = double.Parse(newCar[11]);
                int tire4Age = int.Parse(newCar[12]);

                Engine engine = new Engine(enginePower, engineSpeed);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tire1 tire1 = new Tire1(tire1Pressure, tire1Age);
                Tire2 tire2 = new Tire2(tire2Pressure, tire2Age);
                Tire3 tire3 = new Tire3(tire3Pressure, tire3Age);
                Tire4 tire4 = new Tire4(tire4Pressure, tire4Age);

                Car car = new Car(model, engine, cargo, tire1, tire2, tire3, tire4);
                cars.Add(car);
            }

            var command = Console.ReadLine();
            if (command == "fragile")
            {
                var afterCars = cars.Where(x => x.Cargo.CargoType == "fragile");
                foreach (var afterCar in afterCars)
                {
                    if (afterCar.Tire1.Tire1Pressure < 1)
                    {
                        Console.WriteLine(afterCar.Model);
                    }

                    else if (afterCar.Tire2.Tire2Pressure < 1)
                    {
                        Console.WriteLine(afterCar.Model);
                    }
                    else if (afterCar.Tire3.Tire3Pressure < 1)
                    {
                        Console.WriteLine(afterCar.Model);
                    }
                    else if (afterCar.Tire4.Tire4Pressure < 1)
                    {
                        Console.WriteLine(afterCar.Model);
                    }
                }
            }

            if (command == "flamable")
            {
                var aftercars = cars.Where(x => x.Cargo.CargoType == "flamable");
                foreach (var aftercar in aftercars)
                {
                    if (aftercar.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(aftercar.Model);
                    }
                }
            }
        }
    }
}
