using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks09
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            var sequence = new Stack<string>();
            string text = string.Empty;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                
                var command = Console.ReadLine().Split(' ');
                int a = 0;
                
                switch (command[0])
                {
                    case "1":
                        text += command[1];
                        sequence.Push(text);
                        break;
                    case "2":
                        text = text.Substring(0, text.Length - int.Parse(command[1]));
                        sequence.Push(text);
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(command[1]) - 1]);
                        break;
                    case "4":
                        sequence.Pop();
                        if (sequence.Count > 0)
                        {
                            text = sequence.Peek();
                        }
                        else
                        {
                            text = string.Empty;
                        }                     
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
