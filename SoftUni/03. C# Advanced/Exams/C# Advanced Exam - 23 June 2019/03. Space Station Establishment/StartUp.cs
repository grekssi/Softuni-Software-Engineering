using System;
using System.ComponentModel.Design;
using System.Numerics;

namespace SpaceStation
{
    class Program
    {
        static int firstBHrow = -1;
        static int firstBHcol = -1;
        static int secondBHrow = -1;
        static int secondBHcol = -1;
        static int stephenRow = -1;
        static int stephenCol = -1;
        static void Main(string[] args)
        {
            int starPoits = 0;

            int size = int.Parse(Console.ReadLine());
            var matrix = new char[size][];
            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine(); 
                matrix[row] = new char[currentRow.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];
                    if (matrix[row][col] == 'S')
                    {
                        matrix[row][col] = '-';
                        stephenRow = row;
                        stephenCol = row;
                    }

                    if (matrix[row][col] == 'O')
                    {
                        if (firstBHrow == -1 && firstBHcol == -1)
                        {
                            firstBHrow = row;
                            firstBHcol = col;
                        }
                        else
                        {
                            secondBHrow = row;
                            secondBHcol = col;
                        }
                    }

                }

            }
            while (starPoits < 50)
            {
                string currentCommand = Console.ReadLine();
                if (currentCommand == "right")
                {
                    if (stephenCol + 1 >= matrix[stephenRow].Length)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPoits}");
                        Print(matrix);
                        return;
                    }
                    stephenCol++;
                    if (char.IsDigit(matrix[stephenRow][stephenCol]))
                    {
                        starPoits += int.Parse(matrix[stephenRow][stephenCol].ToString());
                        matrix[stephenRow][stephenCol] = '-';
                    }
                    else if (matrix[stephenRow][stephenCol] == 'O')
                    {
                        matrix = BlackHole(matrix);
                    }
                }

                if (currentCommand == "left")
                {
                    if (stephenCol - 1 < 0)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPoits}");
                        Print(matrix);
                        return;
                    }
                    stephenCol--;
                    if (char.IsDigit(matrix[stephenRow][stephenCol]))
                    {
                        starPoits += int.Parse(matrix[stephenRow][stephenCol].ToString());
                        matrix[stephenRow][stephenCol] = '-';
                    }
                    else if (matrix[stephenRow][stephenCol] == 'O')
                    {
                        matrix = BlackHole(matrix);
                    }
                }

                if (currentCommand == "down")
                {
                    if (stephenRow + 1 >= matrix.Length)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPoits}");
                        Print(matrix);
                        return;
                    }
                    stephenRow++;
                    if (char.IsDigit(matrix[stephenRow][stephenCol]))
                    {
                        starPoits += int.Parse(matrix[stephenRow][stephenCol].ToString());
                        matrix[stephenRow][stephenCol] = '-';
                    }
                    else if (matrix[stephenRow][stephenCol] == 'O')
                    {
                        matrix = BlackHole(matrix);
                    }
                }

                if (currentCommand == "up")
                {
                    if (stephenRow - 1 < 0)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPoits}");
                        Print(matrix);
                        return;
                    }
                    stephenRow--;
                    if (char.IsDigit(matrix[stephenRow][stephenCol]))
                    {
                        starPoits += int.Parse(matrix[stephenRow][stephenCol].ToString());
                        matrix[stephenRow][stephenCol] = '-';
                    }
                    else if (matrix[stephenRow][stephenCol] == 'O')
                    {
                        matrix = BlackHole(matrix);
                    }
                }
            }

            Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {starPoits}");
            matrix[stephenRow][stephenCol] = 'S';
            Print(matrix);
            return;
        }

        static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
        static char[][] BlackHole(char[][] matrix)
        {
            if (stephenRow == firstBHrow && stephenCol == firstBHcol)
            {
                stephenRow = secondBHrow;
                stephenCol = secondBHcol;
                matrix[firstBHrow][firstBHcol] = '-';
                matrix[secondBHrow][secondBHcol] = '-';
                return matrix;
            }
            else
            {
                stephenRow = firstBHrow;
                stephenCol = firstBHcol;
                matrix[firstBHrow][firstBHcol] = '-';
                matrix[secondBHrow][secondBHcol] = '-';
                return matrix;
            }
        }
    }
}
