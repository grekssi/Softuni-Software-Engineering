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
            string setence = Console.ReadLine();
            var letters = new SortedDictionary<char, int>();
            foreach (var item in setence)
            {
                if (letters.ContainsKey(item))
                {
                    letters[item]++;
                }
                else
                {
                    letters.Add(item, 1);
                }
            }
            foreach (var item in letters)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
