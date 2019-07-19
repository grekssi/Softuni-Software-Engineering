using System;

namespace Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCar = Console.ReadLine().Split(' ');
            double fuelQuantity = double.Parse(inputCar[1]);
            double fuelConsumption = double.Parse(inputCar[2]);
            Car car = new Car(fuelQuantity, fuelConsumption);

            var inputTruck = Console.ReadLine().Split(' ');
            fuelQuantity = double.Parse(inputTruck[1]);
            fuelConsumption = double.Parse(inputTruck[2]);
            Truck truck = new Truck(fuelQuantity, fuelConsumption);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(' ');
                double kilometers = double.Parse(command[2]);
                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(kilometers));
                    }

                    if (command[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(kilometers));
                    }
                }

                if (command[0] == "Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(kilometers);
                    }

                    if (command[1] == "Truck")
                    {
                        truck.Refuel(kilometers);
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
