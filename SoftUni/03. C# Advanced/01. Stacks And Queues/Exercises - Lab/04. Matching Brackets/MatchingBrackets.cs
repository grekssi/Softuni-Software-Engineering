using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine();
            var indexes = new Stack<int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (sequence[i] == ')')
                {
                    int startIndex = indexes.Pop();
                    var seq = sequence.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(seq);
                }
            }
        }
    }
}
