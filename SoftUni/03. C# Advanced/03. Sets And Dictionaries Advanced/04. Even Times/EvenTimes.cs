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
            var chemicals = new Dictionary<int, int>();
            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (chemicals.ContainsKey(number))
                {
                    chemicals[number]++;
                }
                else
                {
                    chemicals.Add(number, 1);
                }
            }
            var chemical = chemicals.Where(x => x.Value % 2 == 0).First();
            Console.WriteLine(chemical.Key);
        }
    }
}
