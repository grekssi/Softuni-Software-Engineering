using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp212
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse);
            var numstack = new Stack<int>();
            foreach (var item in numbers)
            {
                numstack.Push(item);
            }
            while (true)
            {
                var firstcom = Console.ReadLine().ToLower();
                if (firstcom == "end")
                {
                    Console.WriteLine("Sum: " + numstack.Sum());
                    break;

                }
                var command = firstcom.Split(' ');
                string operation = command[0].ToLower();
                if (operation == "add")
                {
                    int firstnum = int.Parse(command[1]);
                    int secondnum = int.Parse(command[2]);
                    numstack.Push(firstnum);
                    numstack.Push(secondnum);
                }
                else
                {
                    int toRemove = int.Parse(command[1]);
                    if (numstack.Count >= toRemove)
                    {
                        for (int i = 0; i < toRemove; i++)
                        {
                            numstack.Pop();
                        }
                    }
                }
            }
            

        }
    }
}
