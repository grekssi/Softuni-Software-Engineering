using System;

namespace _01._Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            for (int i = 1; i < size; i++)
            {
                CreateRow(size, i);
            }

            for (int i = size; i >= 1; i--)
            {
                CreateRow(size, i);
            }
        }

        static void CreateRow(int a, int b)
        {
            int spaces = a - b;
            Console.Write(new string(' ', spaces));
            for (int i = 0; i < b; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
