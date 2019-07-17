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
            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] arr = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = numbers[col];
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    
                    break;
                }
                var split = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (split[0] == "swap")
                {
                    try
                    {
                        int row1 = int.Parse(split[1]);
                        int col1 = int.Parse(split[2]);
                        int row2 = int.Parse(split[3]);
                        int col2 = int.Parse(split[4]);
                        string first = arr[row1, col1];
                        string second = arr[row2, col2];
                        arr[row1, col1] = second;
                        arr[row2, col2] = first;

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(arr[row, col] + " ");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
