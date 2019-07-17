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
            char[,] arr = new char[rows, cols];
            string wordinput = Console.ReadLine();
            var word = new Queue<char>();
            foreach (var item in wordinput)
            {
                word.Enqueue(item);
            }          
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char b = word.Peek();
                    word.Enqueue(word.Dequeue());
                    arr[row, col] = b;
                }                
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(arr[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
