using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exc7
{
    class Program
    {
        static void Main(string[] args)
        {
            string paranthesisInput = Console.ReadLine();
            var finalstack = new Stack<char>();
           
            foreach (var item in paranthesisInput)
            {
                switch (item)
                {
                    case '(':
                        finalstack.Push('(');
                        break;
                    case '{':
                        finalstack.Push('{');
                        break;
                    case '[':
                        finalstack.Push('[');
                        break;

                    case ')':
                        if (finalstack.Count <= 0)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else if (finalstack.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '}':
                        if (finalstack.Count <= 0)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        
                        else if (finalstack.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        
                        break;
                    case ']':

                        if (finalstack.Count <= 0)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else if (finalstack.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        
                        break;
                    default:
                        Console.WriteLine("NO");
                        return;
                        break;
                }
            }
            Console.WriteLine("YES");
            
            
        }
    }
}
