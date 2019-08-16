using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CarSalesman //Slaps roof of car! This bad boy
                      //can fit so much f*ckin classes in it
{
    public class StartUp
    {
        static void Main()
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();
            int numberEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberEngines; i++)
            {
                Engine engine = new Engine();
                var info = Console.ReadLine().Split(' ').ToArray();
                string model = info[0];
                int power = int.Parse(info[1]);
                int displacement = -1;
                string efficiency = string.Empty;
                if (info.Length == 3)
                {
                    if (!Int32.TryParse(info[2], out displacement))
                    {
                        efficiency = info[2];
                    }
                    else
                    {
                        displacement = int.Parse(info[2]);
                    }

                }
                if (info.Length == 4)
                {
                    displacement = int.Parse(info[2]);
                    efficiency = info[3];

                }

                engine.Model = model;
                engine.Power = power;
                engine.Efficiency = efficiency;
                engine.Displacement = displacement;
                engines.Add(engine);
            }

            int numberCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberCars; i++)
            {
                Car car = new Car();
                var input = Console.ReadLine().Split(' ').ToArray();
                string model = input[0];
                string engine = input[1];
                int weight = -1;
                string color = string.Empty;
                if (input.Length == 3)
                {
                    if (!Int32.TryParse(input[2], out weight))
                    {
                        color = input[2];
                    }
                    else
                    {
                        weight = int.Parse(input[2]);
                    }
                }

                if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }
                car.Model = model;
                car.Engine = engines.Where(x => x.Model == engine).FirstOrDefault();
                car.Weight = weight;
                car.Color = color;
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"  Power: {car.Engine.Power}");
                if (car.Engine.Displacement <= 0)
                {
                    Console.WriteLine($"  Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"  Displacement: {car.Engine.Displacement}");
                }

                if (car.Engine.Efficiency == string.Empty)
                {
                    Console.WriteLine($"  Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"  Efficiency: {car.Engine.Efficiency}");
                }

                if (car.Weight <= 0)
                {
                    Console.WriteLine($" Weight: n/a");
                }
                else
                {
                    Console.WriteLine($" Weight: {car.Weight}");
                }

                if (car.Color == string.Empty)
                {
                    Console.WriteLine($" Color: n/a");   
                }
                else
                {
                    Console.WriteLine($" Color: {car.Color}");
                }
            }
        }
    }
}
