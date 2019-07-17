using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mystack = new CoolStack<int>();
            var duplicate = new List<int>();
            while (true)
            {
                var command = Console.ReadLine()
                    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "Push")
                {
                    command.RemoveAt(0);
                    duplicate = command.Select(int.Parse).ToList();
                    foreach (var item in duplicate)
                    {
                        mystack.Push(item);
                    }
                }

                if (command[0] == "Pop")
                {
                    mystack.Pop();
                }

                if (command[0] == "END")
                {
                    foreach (var item in mystack)
                    {
                        Console.WriteLine(item);
                    }
                    foreach (var item in mystack)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                }
            }
        }
    }
}
