using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

namespace recursion
{
    class BinarySearch
    {
        static T[] Reverser<T>(T[] items, int leftIndex, int rightIndex, int item)
        {
            for (int i = 1; i <= items.Length / 2; i++)
            {
                var spare = items[i - 1];
                items[i - 1] = items[items.Length - i];
                items[items.Length - i] = spare;
            }

            return items;
        }
        
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Split(' ').ToArray();
        }
    }
}
