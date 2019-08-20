using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queueslab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cur = Console.ReadLine().Split(' ');
            var children = new Queue<string>(cur);
            int toss = int.Parse(Console.ReadLine());
            while (children.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
