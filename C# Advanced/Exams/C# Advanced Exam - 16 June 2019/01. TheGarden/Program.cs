using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarden
{
    class Program
    {
        public static int carrots = 0;
        public static int potatos = 0;
        public static int lettuce = 0;
        public static int harmed = 0;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var garden = new String[rows][];
            for (int row = 0; row < rows; row++)
            {
                var vegetables = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                garden[row] = new String[vegetables.Length];
                for (int col = 0; col < vegetables.Length; col++)
                {
                    garden[row][col] = vegetables[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End of Harvest")
                {
                    Print(garden);
                    Console.WriteLine($"Carrots: {carrots}");
                    Console.WriteLine($"Potatoes: {potatos}");
                    Console.WriteLine($"Lettuce: {lettuce}");
                    Console.WriteLine($"Harmed vegetables: {harmed}");
                    break;
                }

                var split = command.Split(' ');
                string move = split[0];
                int row = int.Parse(split[1]);
                int col = int.Parse(split[2]);
                if (move == "Harvest")
                {
                    Harvest(garden, row, col);
                }

                if (move == "Mole")
                {
                    string direction = split[3];
                    Mole(row, col, direction, garden);
                }

            }
        }

        private static void Mole(int row, int col, string direction, string[][] garden)
        {
            if (direction == "up")
            {
                try
                {
                    for (int i = row; i >= 0; i -= 2)
                    {
                        if (garden[i][col] != " ")
                        {
                            harmed++;
                        }
                        garden[i][col] = " ";
                    }
                }

                catch (Exception e)
                {

                }
            }

            if (direction == "right")
            {
                try
                {
                    for (int i = col; i < garden[row].Length; i += 2)
                    {
                        if (garden[row][i] != " ")
                        {
                            harmed++;
                        }
                        garden[row][i] = " ";
                    }
                }

                catch (Exception e)
                {

                }
            }

            if (direction == "left")
            {
                try
                {
                    for (int i = col; i >= 0; i -= 2)
                    {
                        if (garden[row][i] != " ")
                        {
                            harmed++;
                        }
                        garden[row][i] = " ";
                    }
                }

                catch (Exception e)
                {

                }
            }

            if (direction == "down")
            {
                try
                {
                    for (int i = row; i < garden.Length; i += 2)
                    {
                        if (garden[i][col] != " ")
                        {
                            harmed++;
                        }
                        garden[i][col] = " ";
                    }
                }

                catch (Exception e)
                {

                }
            }
        }

        private static void Harvest(string[][] garden, int row, int col)
        {
            try
            {
                switch (garden[row][col])
                {
                    case "C":
                        carrots++;
                        garden[row][col] = " ";
                        break;
                    case "L":
                        lettuce++;
                        garden[row][col] = " ";
                        break;
                    case "P":
                        potatos++;
                        garden[row][col] = " ";
                        break;
                }
            }
            catch (Exception e)
            {
            }
        }


        static void Print(string[][] garden)
        {
            for (int row = 0; row < garden.Length; row++)
            {
                for (int col = 0; col < garden[row].Length; col++)
                {
                    Console.Write(garden[row][col] + " ");
                }
                Console.WriteLine(' ');
            }
        }
    }
}
