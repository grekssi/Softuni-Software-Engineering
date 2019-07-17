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
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n,n];
            for (int row = 0; row < n; row++)
            {
                var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            var inputBombs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            foreach (var item in inputBombs)
            {
                var bomb = item.Split(',').Select(int.Parse).ToArray();
                int row = bomb[0];
                int col = bomb[1];
                int explosion = matrix[row, col];
                if (explosion > 0)
                {
                    matrix[row, col] = 0;
                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= explosion;
                        }

                    }
                    if (row + 1 < matrix.GetLength(0))
                    {
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= explosion;
                        }

                    }
                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= explosion;
                        }

                    }
                    if (col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= explosion;
                        }

                    }
                    if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= explosion;
                        }

                    }
                    if (row + 1 < matrix.GetLength(0) && col - 1 >= 0)
                    {
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= explosion;
                        }

                    }
                    if (row - 1 >= 0 && col + 1 < matrix.GetLength(0))
                    {
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= explosion;
                        }

                    }
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= explosion;
                        }

                    }
                }
                
            }
            int alive = 0;
            int sumOfAlive = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {             
                    if (matrix[row, col] > 0)
                    {
                        alive++;
                        sumOfAlive += matrix[row, col];
                    }
                }
            }
            Console.WriteLine("Alive cells: " + alive);
            Console.WriteLine("Sum: " + sumOfAlive);
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");                  
                }
                Console.WriteLine();
            }
            
        }
    }
}
