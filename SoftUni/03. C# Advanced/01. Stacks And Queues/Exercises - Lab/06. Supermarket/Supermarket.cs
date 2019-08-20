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
            var customers = new Queue<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine($"{customers.Count()} people remaining.");
                    break;
                }
                if (command == "Paid")
                {
                    foreach (var item in customers)
                    {
                        Console.WriteLine(item);
                    }
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(command);
                }
            }
        }
    }
}
