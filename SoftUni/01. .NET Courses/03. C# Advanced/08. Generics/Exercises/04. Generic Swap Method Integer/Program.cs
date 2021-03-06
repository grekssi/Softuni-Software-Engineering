﻿using System;
using System.Linq;

namespace Generics3
{
    class Program
    {
        static void Main(string[] args)
        {
            Swapper<int> swapper = new Swapper<int>();

            var size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                var command = int.Parse(Console.ReadLine());
                swapper.Add(command);
            }

            var indeces = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int index1 = indeces[0];
            int index2 = indeces[1];
            swapper.Swap(index1, index2);

            Console.WriteLine(swapper.ToString());
        }
    }
}
