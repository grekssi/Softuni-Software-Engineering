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
            int size = int.Parse(Console.ReadLine());
            var matrix = new string[size, size];
            var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int minerRow = 0;
            int minerCol = 0;
            int totalCoal = 0;
            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < size; col++)
                {
                    if (line[col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (line[col] == "c")
                    {
                        totalCoal++;
                    }
                    matrix[row, col] = line[col];
                }
            }

            int minedCoal = 0;
            foreach (var item in commands)
            {
                switch (item)
                {
                    case "up":
                        if (minerRow - 1 >= 0)
                        {
                            matrix[minerRow, minerCol] = "*";
                            if (matrix[minerRow - 1, minerCol] == "c")
                            {
                                minedCoal++;
                                if (minedCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRow - 1}, {minerCol})");
                                    return;
                                }
                            }
                            else if (matrix[minerRow - 1, minerCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRow + 1}, {minerCol})");
                                return;
                            }

                            matrix[minerRow - 1, minerCol] = "s";
                            minerRow -= 1;


                        }

                        break;
                    case "down":
                        if (minerRow + 1 < matrix.GetLength(0))
                        {
                            matrix[minerRow, minerCol] = "*";
                            if (matrix[minerRow + 1, minerCol] == "c")
                            {
                                minedCoal++;
                                if (minedCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRow + 1}, {minerCol})");
                                    return;
                                }
                            }
                            else if (matrix[minerRow + 1, minerCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRow + 1}, {minerCol})");
                                return;
                            }

                            matrix[minerRow + 1, minerCol] = "s";
                            minerRow += 1;


                        }

                        break;
                    case "right":
                        if (minerCol + 1 < matrix.GetLength(1))
                        {
                            matrix[minerRow, minerCol] = "*";
                            if (matrix[minerRow, minerCol + 1] == "c")
                            {
                                minedCoal++;
                                if (minedCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol + 1})");
                                    return;
                                }
                            }
                            else if (matrix[minerRow, minerCol + 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRow}, {minerCol + 1})");
                                return;
                            }

                            matrix[minerRow, minerCol + 1] = "s";
                            minerCol += 1;


                        }

                        break;
                    case "left":
                        if (minerCol - 1 >= 0)
                        {
                            matrix[minerRow, minerCol] = "*";
                            if (matrix[minerRow, minerCol - 1] == "c")
                            {
                                minedCoal++;
                                if (minedCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol - 1})");
                                    return;
                                }
                            }
                            else if (matrix[minerRow, minerCol - 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRow}, {minerCol - 1})");
                                return;
                            }

                            matrix[minerRow, minerCol - 1] = "s";
                            minerCol -= 1;


                        }

                        break;
                    default:
                        break;
                }
            }
            int left = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == "c")
                    {
                        left++;
                    }
                }
            }
            Console.WriteLine($"{left} coals left. ({minerRow}, {minerCol})");

        }
    }
}
