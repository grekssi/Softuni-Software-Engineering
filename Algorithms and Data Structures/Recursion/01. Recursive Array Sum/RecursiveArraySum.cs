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
        static int[] numbers = new int[] {1, 2, 3, 4, 5};
        static int Sum(int index)
        {
            if (index == numbers.Length)
            {
                return 0;
            }

            else
            {
                return numbers[index] + Sum(index + 1);
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(0));
        }
    }
}
