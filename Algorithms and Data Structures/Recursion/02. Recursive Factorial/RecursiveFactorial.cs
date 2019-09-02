using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

namespace recursion
{
    class BinarySearch
    {
        static int FactorialSum(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            else
            {
                return number * FactorialSum(number - 1);
            }
        }
        
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(FactorialSum(number));
        }
    }
}
