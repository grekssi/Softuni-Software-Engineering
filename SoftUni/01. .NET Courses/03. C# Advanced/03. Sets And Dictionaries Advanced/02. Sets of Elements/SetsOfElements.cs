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
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];
            var firtSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var finalSet = new HashSet<int>();
            for (int i = 0; i < n + m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    firtSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }
            foreach (var item in firtSet)
            {
                foreach (var kv in secondSet)
                {
                    if (item == kv)
                    {
                        finalSet.Add(item);
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", finalSet.ToArray()));
        }
    }
}
