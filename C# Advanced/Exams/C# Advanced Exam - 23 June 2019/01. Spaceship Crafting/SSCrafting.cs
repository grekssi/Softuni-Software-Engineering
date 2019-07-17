using System;

namespace blackhole
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new char[size,size];

            int starpoints = 0;

            int stephenRow = 0;
            int stephenCol = 0;

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        stephenRow = row;
                        stephenCol = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            while (starpoints < 50)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    try
                    {
                        if (matrix[--stephenRow,stephenCol] == 'O')
                        {
                            matrix[stephenRow, stephenCol] = '-';
                            for (int row = stephenRow; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        stephenRow = row;
                                        stephenCol = col;
                                        matrix[row, col] = '-';
                                        break;
                                    }
                                }
                            }
                        }

                        if (char.IsDigit(matrix[stephenRow, stephenCol]))
                        {
                            starpoints += int.Parse(matrix[stephenRow, stephenCol].ToString());
                            matrix[stephenRow,stephenCol] = '-';
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starpoints}");
                        Print(matrix);
                        return;
                    }
                }
                if (command == "down")
                {
                    try
                    {
                        if (matrix[++stephenRow, stephenCol] == 'O')
                        {
                            matrix[stephenRow, stephenCol] = '-';
                            for (int row = stephenRow; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        stephenRow = row;
                                        stephenCol = col;
                                        matrix[row, col] = '-';
                                        break;
                                    }
                                }
                            }
                        }

                        if (char.IsDigit(matrix[stephenRow, stephenCol]))
                        {
                            starpoints += int.Parse(matrix[stephenRow, stephenCol].ToString());
                            matrix[stephenRow, stephenCol] = '-';
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starpoints}");
                        Print(matrix);
                        return;
                    }
                }
                if (command == "left")
                {
                    try
                    {
                        if (matrix[stephenRow, --stephenCol] == 'O')
                        {
                            matrix[stephenRow, stephenCol] = '-';
                            for (int row = stephenRow; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        stephenRow = row;
                                        stephenCol = col;
                                        matrix[row, col] = '-';
                                        break;
                                    }
                                }
                            }
                        }

                        if (char.IsDigit(matrix[stephenRow, stephenCol]))
                        {
                            starpoints += int.Parse(matrix[stephenRow, stephenCol].ToString());
                            matrix[stephenRow, stephenCol] = '-';
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starpoints}");
                        Print(matrix);
                        return;
                    }
                }
                if (command == "right")
                {
                    try
                    {
                        if (matrix[stephenRow, ++stephenCol] == 'O')
                        {
                            matrix[stephenRow, stephenCol] = '-';
                            for (int row = stephenRow; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        stephenRow = row;
                                        stephenCol = col;
                                        matrix[row, col] = '-';
                                        break;
                                    }
                                }
                            }
                        }

                        if (char.IsDigit(matrix[stephenRow, stephenCol]))
                        {
                            starpoints += int.Parse(matrix[stephenRow, stephenCol].ToString());
                            matrix[stephenRow, stephenCol] = '-';
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starpoints}");
                        Print(matrix);
                        return;
                    }
                }
            }

            Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {starpoints}");
            matrix[stephenRow, stephenCol] = 'S';
            Print(matrix);
            return;


        }

        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
