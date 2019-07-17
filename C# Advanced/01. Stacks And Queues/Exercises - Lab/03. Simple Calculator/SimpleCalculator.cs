using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(' ').Reverse();
            var numstack = new Stack<string>();
            int total = 0;
            foreach (var item in command)
            {
                numstack.Push(item);
            }
            
            while (numstack.Count > 0)
            {
                string nextNum = numstack.Peek();
                
                switch (nextNum)
                {
                    case "-":
                        numstack.Pop();
                        total -= int.Parse(numstack.Peek());
                        numstack.Pop();
                        break;
                    case "+":
                        numstack.Pop();
                        total += int.Parse(numstack.Peek());
                        numstack.Pop();
                        break;
                    default:
                        total += int.Parse(numstack.Peek());
                        numstack.Pop();
                        break;
                }
            }
            Console.WriteLine(total);

        }
    }
}
