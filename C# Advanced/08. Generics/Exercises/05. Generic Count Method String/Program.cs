using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics4
{
    class Program
    {
        static void Main(string[] args)
        {
            var comparer = new Comparator<string>();
            int size = int.Parse(Console.ReadLine());
            var toCompate = new int[size];
            for (int i = 0; i < size; i++)
            {
                string currentSequence = Console.ReadLine();
                comparer.Add(currentSequence);
            }
            string compareTo = Console.ReadLine();
            Console.WriteLine(CompareElements(comparer.data, compareTo));
        }

        private static int CompareElements<T>(List<T> data, string compareTo)
        {
            int count = 0;
            foreach (var item in data)
            {
                if (compareTo.CompareTo(item) < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
