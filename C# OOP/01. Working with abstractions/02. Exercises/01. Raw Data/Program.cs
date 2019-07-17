using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            int numberCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberCars; i++)
            {
                var information = Console.ReadLine().Split(' ').ToArray();
                string model = information[0];
                int engineSpeed = int.Parse(information[1]);
                int enginePower = int.Parse(information[2]);
                int cargoWeight = int.Parse(information[3]);
                string cargoType = information[4];

                double tyre1Pressure = double.Parse(information[5]);
                int tyre1Age = int.Parse(information[6]);
                double tyre2Pressure = double.Parse(information[7]);
                int tyre2Age = int.Parse(information[8]);
                double tyre3Pressure = double.Parse(information[9]);
                int tyre3Age = int.Parse(information[10]);
                double tyre4Pressure = double.Parse(information[11]);
                int tyre4Age = int.Parse(information[12]);

                Tire tire = new Tire(tyre1Pressure, tyre1Age, tyre2Pressure, tyre2Age,
                    tyre3Pressure, tyre3Age, tyre4Pressure, tyre4Age);
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, cargo, engine, tire);
                cars.Add(car);
            }

            string cargoToSearch = Console.ReadLine();
            if (cargoToSearch == "fragile")
            {
                var SeachedFor = cars.Where(x => x.cargo.type == cargoToSearch)
                    .Where(x => x.tire.minPressure < 1);
                foreach (var car in SeachedFor)
                {
                    Console.WriteLine(car.Model);
                }
            }

            if (cargoToSearch == "flamable")
            {
                var SeachedFor = cars.Where(x => x.cargo.type == cargoToSearch).Where(x => x.engine.power > 250);
                foreach (var car in SeachedFor)
                {
                    Console.WriteLine(car.Model);
                }
            }
            
        }
    }
}
