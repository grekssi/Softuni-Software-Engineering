using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var a = Console.ReadLine().Split(' ');
                switch (a[0])
                {
                    case "1":
                        numbers.Push(int.Parse(a[1]));
                        break;
                    case "2":
                        if (numbers.Count >= 1)
                        {
                            numbers.Pop();
                        }
                        
                        break;
                    case "3":
                        if (numbers.Count >= 1)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        
                        break;
                    case "4":
                        if (numbers.Count >= 1)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        
                        break;
                    default:
                        break;
                }
                
            }
            Console.WriteLine(string.Join(", ", numbers.ToArray()));
        }
    }
}
