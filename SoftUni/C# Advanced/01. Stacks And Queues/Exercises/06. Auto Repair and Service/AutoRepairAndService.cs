using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var cars = new Queue<string>(input);
            var servedCars = new Stack<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    if (cars.Count > 0)
                    {
                        Console.WriteLine($"Vehicles for service: {string.Join(", ", cars.ToArray())}");

                    }
                    if (servedCars.Count > 0)
                    {
                        Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars.ToArray())}");
                    }
                    
                    break;
                }
                if (command == "Service")
                {
                    if (cars.Count > 0)
                    {
                        string car = cars.Dequeue();
                        Console.WriteLine($"Vehicle {car} got served.");
                        servedCars.Push(car);
                    }
                    
                }
                if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars.ToArray()));
                }
                if (command.Contains("CarInfo"))
                {
                    var split = command.Split('-');
                    string cartoSearch = split[1];
                    if (servedCars.Contains(cartoSearch))
                    {
                        Console.WriteLine("Served.");
                    }
                    else if (cars.Contains(cartoSearch))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }
            }

        }
    }
}
