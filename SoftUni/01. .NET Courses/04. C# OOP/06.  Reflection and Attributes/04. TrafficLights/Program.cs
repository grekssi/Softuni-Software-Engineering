using System;
using System.Collections.Generic;
using System.Linq;

namespace Inferno_Infinity
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] pattern = new string[] {"red", "green", "yellow"};
            var inputColor = Console.ReadLine().Split(' ').Select(x => new TrafficLight(x)).ToList();
            int iterations = int.Parse(Console.ReadLine());

            for (int i = 0; i < iterations; i++)
            {
                inputColor.ForEach(x => x.ChangeColor());
                Console.WriteLine(string.Join(" ", inputColor));
            }
        }
    }
}
