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
            var chemicals = new SortedSet<string>();
            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                var command = Console.ReadLine().Split(' ').ToArray();
                foreach (var item in command)
                {
                    chemicals.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", chemicals.ToArray()));
        }
    }
}
