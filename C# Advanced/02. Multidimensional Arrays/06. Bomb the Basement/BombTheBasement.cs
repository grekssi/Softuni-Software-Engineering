using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            var bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int bombrow = bomb[0];
            int bombcol = bomb[1];
            int bombsize = bomb[2];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isInside = Math.Pow(row - bombrow, 2) + Math.Pow(col - bombcol, 2) <= Math.Pow(bombsize, 2);
                    if (isInside)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }
           
            for (int col = 0; col < cols; col++)
            {
                int counter = 0;
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        counter++;
                        matrix[row, col] = 0;
                    }
                }
                for (int i = 0; i < counter; i++)
                {
                    matrix[i, col] = 1;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
