using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp216
{
    class Program
    {
        static void Main(string[] args)
        {
            var myset = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                myset.Add(name);
            }
            foreach (var item in myset)
            {
                Console.WriteLine(item);
            }
        }
    }
}
