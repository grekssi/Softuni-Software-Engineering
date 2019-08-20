using System;
using System.Linq;

namespace advancedArraysExs1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] arr = new int[size,size];
            int a = size - 1;
            int total1 = 0;            
            int total2 = 0;            
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < input.Length; col++)
                {
                    arr[row, col] = input[col];
                }
            }
            
            for (int row = 0; row < size; row++)
            {
                total1 += arr[row, row];
            }
            for (int row = 0; row < size; row++)
            {
                
                total2 += arr[row, a];
                a -= 1;

            }
            Console.WriteLine(Math.Abs(total1 - total2));
            
        }
    }
}
