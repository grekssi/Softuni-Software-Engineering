using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp217
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            var dresser = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < iterations; i++)
            {
                var command = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var other = command[1].Split(',');
                string color = command[0];
                if (!dresser.ContainsKey(color))
                {
                    dresser.Add(color, new Dictionary<string, int>());
                    
                }
                foreach (var item in other)
                {
                    if (dresser[color].ContainsKey(item))
                    {
                        dresser[color][item]++;
                    }
                    else
                    {
                        dresser[color].Add(item, 1);
                    }
                }
            }
            var itemsToSearchFor = Console.ReadLine().Split(' ');

            var colorToSearchFor = itemsToSearchFor[0];
            var dressToSearchFor = itemsToSearchFor[1];
            foreach (var item in dresser)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var kvp in item.Value)
                {
                    if (item.Key == colorToSearchFor && kvp.Key == dressToSearchFor)
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
