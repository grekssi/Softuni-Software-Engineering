using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrsesc
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long rows = input[0];
            var cols = input[1];
            long total = 0;
            long[,] arr = new long[rows, cols];
            long[,] saved = new long[3, 3];
            for (long row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (long col = 0; col < cols; col++)
                {
                    arr[row, col] = currentRow[col];
                }
            }
            for (long row = 0; row < rows - 2; row++)
            {
                for (long col = 0; col < cols - 2; col++)
                {
                    if (arr[row,col]
                        + arr[row, col + 1]
                        + arr[row, col + 2]
                        + arr[row + 1, col]
                        + arr[row + 1, col + 1]
                        + arr[row + 1, col + 2]
                        + arr[row + 2, col]
                        + arr[row + 2, col + 1]
                        + arr[row + 2, col + 2] > total)
                    {
                        total = arr[row, col]
                        + arr[row, col + 1]
                        + arr[row, col + 2]
                        + arr[row + 1, col]
                        + arr[row + 1, col + 1]
                        + arr[row + 1, col + 2]
                        + arr[row + 2, col]
                        + arr[row + 2, col + 1]
                        + arr[row + 2, col + 2];
                        long a = row;
                        long b = col;
                        for (long row1 = 0; row1 < 3; row1++)
                        {
                            b = col;
                            for (long col1 = 0; col1 < 3; col1++)
                            {
                                saved[row1, col1] = arr[a, b];                                
                                b++;
                            }
                            a++;
                        }
                    }
                    
                }
            }
            Console.WriteLine($"Sum = {total}");
            for (long row = 0; row < 3; row++)
            {
                for (long col = 0; col < 3; col++)
                {
                    Console.Write(saved[row, col] + " ");
                }
                Console.WriteLine();
            }
           
        }
    }
}
