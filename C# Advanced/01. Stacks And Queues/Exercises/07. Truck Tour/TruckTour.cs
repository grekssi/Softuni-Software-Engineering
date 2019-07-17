using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exc7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var fuelPump = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                fuelPump.Enqueue(command);
            }
            int totalfuel = 0;
            int index = 0;
            while (true)
            {
                totalfuel = 0;
                foreach (var item in fuelPump)
                {   
                    int fuel = item[0];
                    int kmters = item[1];
                    totalfuel += fuel - kmters;
                    if (totalfuel < 0)
                    {
                        fuelPump.Enqueue(fuelPump.Dequeue());
                        index++;
                        break;
                    }
                }
                if (totalfuel >= 0)
                {
                    Console.WriteLine(index);
                    break;
                }
            }
     
            
            
        }
    }
}
