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
            double tankCapacity = double.Parse(inputCar[3]);
            VehicleAbstract car = new Car(tankCapacity, fuelQuantity, fuelConsumption);

            var inputTruck = Console.ReadLine().Split(' ');
            fuelQuantity = double.Parse(inputTruck[1]);
            fuelConsumption = double.Parse(inputTruck[2]);
            tankCapacity = double.Parse(inputTruck[3]);
            VehicleAbstract truck = new Truck(tankCapacity, fuelQuantity, fuelConsumption);

            var inputBus = Console.ReadLine().Split(' ');
            fuelQuantity = double.Parse(inputBus[1]);
            fuelConsumption = double.Parse(inputBus[2]);
            tankCapacity = double.Parse(inputBus[3]);
            Bus bus = new Bus(tankCapacity, fuelQuantity, fuelConsumption);


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

                    if (command[1] == "Bus")
                    {
                        Console.WriteLine(bus.DriveFull(kilometers));
                    }
                }

                if (command[0] == "DriveEmpty")
                {
                    Console.WriteLine(bus.Drive(kilometers));
                }

                if (command[0] == "Refuel")
                {
                    try
                    {
                        if (command[1] == "Car")
                        {
                            car.Refuel(kilometers);
                        }

                        if (command[1] == "Truck")
                        {
                            truck.Refuel(kilometers);
                        }

                        if (command[1] == "Bus")
                        {
                            bus.Refuel(kilometers);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
