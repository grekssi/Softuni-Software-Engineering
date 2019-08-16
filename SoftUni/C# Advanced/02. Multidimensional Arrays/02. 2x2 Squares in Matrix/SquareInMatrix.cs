using System;
using System.Linq;

namespace advancedArraysExs1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowscols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowscols[0];
            int cols = rowscols[1];
            int total = 0;
            string[,] arr = new string[rows, cols];            
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = input[col];
                }
            }
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    string current = arr[row, col];
                    if (arr[row + 1, col] == current
                        && arr[row, col + 1] == current 
                        && arr[row + 1, col + 1] == current)
                    {
                        total++;
                    }
                }
            }
            Console.WriteLine(total);
            
        }
    }
}
