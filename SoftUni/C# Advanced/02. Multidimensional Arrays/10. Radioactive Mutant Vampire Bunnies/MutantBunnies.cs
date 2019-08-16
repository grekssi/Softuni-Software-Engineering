using System;
using System.Linq;


namespace ConsoleApp221
{
    class Program
    {
        static int deadRow = 0;
        static int deadCol = 0;
        static void Main(string[] args)
        {
            var rowAndCol = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowAndCol[0];
            int cols = rowAndCol[1];
            var field = new char[rows,cols];
            int playerRow = 0;
            int playerCol = 0;
            
            bool dead = false;
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    field[row, col] = line[col];
                }
            }

            string input = Console.ReadLine();
            foreach (var item in input)
            {
                
                if (item == 'U')
                {
                    if (playerRow - 1 < 0) //tuk pecheli
                    {
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, false);
                        Print(field);
                        Console.WriteLine($"won: {playerRow}{playerCol}");
                        return;
                    }
                    else if (field[playerRow - 1,playerCol] == 'B') //tuk umira 
                    {
                        deadRow = playerRow - 1;
                        deadCol = playerCol;
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, true);
                        return;
                    }
                    else //tuk ne stava nishto, samo se mestim
                    {
                        field[playerRow, playerCol] = '.';
                        field[playerRow - 1, playerCol] = 'P';
                        playerRow -= 1;
                        Bunnies(field, dead);
                        if (dead == true)
                        {
                            Print(field);
                            Console.WriteLine($"dead: {deadRow} {deadCol}");
                            return;
                        }
                    }
                }
                if (item == 'D')
                {
                    if (playerRow + 1 >= field.GetLength(0)) //tuk pecheli
                    {
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, false);
                        Print(field);
                        Console.WriteLine($"won: {playerRow}{playerCol}");
                        return;
                    }
                    else if (field[playerRow + 1, playerCol] == 'B') //tuk umira 
                    {
                        deadRow = playerRow + 1;
                        deadCol = playerCol;
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, true);
                        return;
                    }
                    else //tuk ne stava nishto, samo se mestim
                    {
                        field[playerRow, playerCol] = '.';
                        field[playerRow + 1, playerCol] = 'P';
                        playerRow += 1;
                        Bunnies(field, dead);
                        if (dead == true)
                        {
                            Print(field);
                            Console.WriteLine($"dead: {deadRow} {deadCol}");
                            return;
                        }
                    }
                }

                if (item == 'L')
                {
                    if (playerCol - 1 < 0) //pechelim
                    {
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, false);
                        Print(field);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        return;
                    }
                    else if (field[playerRow, playerCol - 1] == 'B') // tuk umirame
                    {
                        deadRow = playerRow;
                        deadCol = playerCol - 1;
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, true);
                        return;
                    }
                    else 
                    {
                        field[playerRow, playerCol] = '.';
                        field[playerRow, playerCol - 1] = 'P';
                        playerCol -= 1;
                        Bunnies(field, dead);
                        if (dead == true)
                        {
                            Print(field);
                            Console.WriteLine($"dead: {deadRow} {deadCol}");
                            return;
                        }
                    }
                }
                if (item == 'R')
                {
                    if (playerCol + 1 >= field.GetLength(1)) //pechelim
                    {
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, false);
                        Print(field);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        return;
                    }
                    else if (field[playerRow, playerCol + 1] == 'B') // tuk umirame
                    {
                        deadRow = playerRow;
                        deadCol = playerCol + 1;
                        field[playerRow, playerCol] = '.';
                        Bunnies(field, true);
                        return;
                    }
                    else
                    {
                        field[playerRow, playerCol] = '.';
                        field[playerRow, playerCol + 1] = 'P';
                        playerCol += 1;
                        Bunnies(field, dead);
                        if (dead == true)
                        {
                            Print(field);
                            Console.WriteLine($"dead: {deadRow} {deadCol}");
                            return;
                        }
                    }
                }

            }
        }

        private static void Print(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Bunnies(char[,] field, bool IsDead)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        if (row - 1 >= 0) //nagore
                        {
                            if (field[row - 1, col] == 'P')
                            {
                                IsDead = true;
                                deadRow = row - 1;
                                deadCol = col;
                                field[row - 1, col] = 'C';
                            }

                            if (field[row - 1, col] == '.')
                            {
                                field[row - 1, col] = 'C';
                            }
                        }

                        if (row + 1 < field.GetLength(0)) //nadolu
                        {
                            if (field[row + 1, col] == 'P')
                            {
                                IsDead = true;
                                deadRow = row + 1;
                                deadCol = col;
                                field[row + 1, col] = 'C';
                            }

                            if (field[row + 1, col] == '.')
                            {
                                field[row + 1, col] = 'C';
                            }
                        }

                        if (col + 1 < field.GetLength(1)) //nadqsno
                        {
                            if (field[row, col + 1] == 'P')
                            {
                                IsDead = true;
                                deadRow = row;
                                deadCol = col + 1;
                                field[row, col + 1] = 'C';
                            }

                            if (field[row, col + 1] == '.')
                            {
                                field[row, col + 1] = 'C';
                            }
                        }

                        if (col - 1 >= 0) //nalqvo
                        {
                            if (field[row, col - 1] == 'P')
                            {
                                IsDead = true;
                                deadRow = row;
                                deadCol = col - 1;
                                field[row, col - 1] = 'C';
                            }

                            if (field[row, col - 1] == '.')
                            {
                                field[row, col - 1] = 'C';
                            }
                        }
                    }
                }
            }
            
           
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'C')
                    {
                        field[row, col] = 'B';
                    }
                }
            }
          
            if (IsDead == true) 
            {
                Print(field);
                Console.WriteLine($"dead: {deadRow} {deadCol}");
            }
        }
    }
}
