using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp200
{
    class Program
    {
        static void Main(string[] args)
        {
            var areaAndCout = new Dictionary<string, int>();
            var NameAndFood = new Dictionary<string, int>();
            while (true)
            {
                string command = Console.ReadLine();
                var split = command.Split(':');
                if (command == "Last Info")
                {
                    Console.WriteLine("Animals:");
                    foreach (var item in NameAndFood.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}g");
                    }
                    Console.WriteLine("Areas with hungry animals:");
                    foreach (var item in areaAndCout.Where(x => x.Value > 0).OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"{item.Key} : {item.Value}");
                    }
                    break;
                }
                if (split[0] == "Add")
                {
                    string name = split[1];
                    int foodLimit = int.Parse(split[2]);
                    string area = split[3];

                    if (NameAndFood.ContainsKey(name))
                    {
                        NameAndFood[name] += foodLimit;

                    }
                    else
                    {
                        NameAndFood.Add(name, foodLimit);
                        if (areaAndCout.ContainsKey(area))
                        {
                            areaAndCout[area] += 1;
                        }
                        else
                        {
                            areaAndCout.Add(area, 1);
                        }
                    }
                    
                }
                else
                {
                    string name = split[1];
                    int foodAmout = int.Parse(split[2]);
                    string area = split[3];
                    if (NameAndFood.ContainsKey(name))
                    {
                        NameAndFood[name] -= foodAmout;
                        if (NameAndFood[name] <= 0)
                        {
                            Console.WriteLine($"{name} was successfully fed");
                            NameAndFood.Remove(name);
                            areaAndCout[area] -= 1;
                        }
                    }
                   
                }
            }
        }
    }
}
