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
            int fieldSize = int.Parse(Console.ReadLine());
            var field = new char[fieldSize, fieldSize];
            int horseAttacks = 0;
            int removed = 0;
            for (int row = 0; row < fieldSize; row++)
            {
                string sentence = Console.ReadLine();
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = sentence[col];
                }
            }
            int[] attacks = new int[] { 1, 2, 1, -2, -1, 2, -1, -2, 2, 1, 2, -1, -2, 1, -2, -1 };
            while (true)
            {
                int bestattacks = 0;
                int bestcol = 0;
                int bestrow = 0;
                for (int row = 0; row < fieldSize; row++)
                {
                    for (int col = 0; col < fieldSize; col++)
                    {
                        int currentHorse = 0;
                        if (field[row, col] == 'K')
                        {
                            for (int i = 0; i < attacks.Length; i+=2)
                            {
                                if (Isinside(field, row + attacks[i], col + attacks[i + 1]) 
                                    && field[row + attacks[i], col + attacks[i + 1]] == 'K')
                                {
                                    currentHorse++;
                                }
                            }
                            
                        }
                        if (currentHorse > bestattacks)
                        {
                            bestattacks = currentHorse;
                            bestcol = col;
                            bestrow = row;
                        }

                    }
                }
                if (bestattacks == 0)
                {
                    break;
                }
                field[bestrow, bestcol] = '0';
                removed++;
            }
            Console.WriteLine(removed);

        }

        private static bool Isinside(char[,] field, int desiredRow, int desiredCol)
        {
            return desiredRow >= 0 && desiredRow < field.GetLength(0) && desiredCol >= 0 && desiredCol < field.GetLength(1);
            
        }
    }
}
