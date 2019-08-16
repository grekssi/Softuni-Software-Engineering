using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputbottles = Console.ReadLine().Split(' ').Select(int.Parse);
            var inputcups = Console.ReadLine().Split(' ').Select(int.Parse);
            var bottles = new Stack<int>(inputcups);
            var cups = new Queue<int>(inputbottles);
            int wasted = 0;
            while (bottles.Any() && cups.Any())
            {
                    
                if (cups.Peek() > bottles.Peek())
                {
                    int remaining = 0;
                    int currentCup = cups.Dequeue();
                    while (currentCup > 0)
                    {
                        int currentBottle = bottles.Pop();
                        currentCup -= currentBottle;
                        remaining = currentCup * -1;
                    }
                    wasted += remaining;
                }
                else
                {
                    int currentBottle = bottles.Pop();
                    int currentCup = cups.Dequeue();
                    wasted += currentBottle - currentCup;
                }
            }
            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles.ToArray())}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups.ToArray())}");
            }
            Console.WriteLine("Wasted litters of water: " + wasted);
            

        }
    }
}
