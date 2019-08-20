using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks9
{
    class Program
    {
        static void Main(string[] args)
        {
            long biggestOrder = 0;
            long foodQuantity = long.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);
            var orders = new Queue<long>(input);
            while (orders.Count > 0)
            {
                var currentOrder = orders.Peek();
                if (currentOrder >= biggestOrder)
                {
                    biggestOrder = currentOrder;
                }
                if (foodQuantity - currentOrder >= 0)
                {
                    orders.Dequeue();
                    foodQuantity -= currentOrder;
                    
                    
                    if (orders.Count == 0)
                    {
                        break;
                    }
                }
                
                else
                {
                    Console.WriteLine(biggestOrder);
                    Console.WriteLine($"Orders left: {string.Join(" ", orders.ToArray())}");
                    return;
                }
                
            }
            Console.WriteLine($"{biggestOrder}");
            Console.WriteLine("Orders complete");
        }
    }
}
