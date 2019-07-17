using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacksexs3
{
    class Program
    {
        static void Main(string[] args)
        {
            var reversed = new Stack<char>();
            string sequence = Console.ReadLine();
            foreach (var item in sequence)
            {
                reversed.Push(item);
            }
            Console.WriteLine(string.Join("", reversed.ToArray()));
        }
    }
}
