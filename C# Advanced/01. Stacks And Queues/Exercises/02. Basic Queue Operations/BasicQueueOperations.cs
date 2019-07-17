using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks1
{
    class Program
    {
        static void Main(string[] args)
        {
            var NSX = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int toPush = NSX[0];
            int toPop = NSX[1];
            int toLookFor = NSX[2];
            var numbers = new Queue<int>();
            for (int i = 0; i < toPush; i++)
            {
                numbers.Enqueue(inputNumbers[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                if (numbers.Count > 0)
                {
                    numbers.Dequeue();
                }
            }
            if (numbers.Contains(toLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
                
            }
        }
    }
}
