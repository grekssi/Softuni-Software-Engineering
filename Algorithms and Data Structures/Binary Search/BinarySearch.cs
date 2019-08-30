using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace recursion
{
    class BinarySearch
    {
        static int Search(List<int> items, int leftIndex, int rightIndex, int item)
        {
            if (rightIndex < leftIndex)
            {
                return -1;
            }

            int middle = leftIndex + (rightIndex - leftIndex) / 2;

            if (items[middle] == item)
            {
                return middle;
            }

            if (items[middle] > item)
            {
                return Search(items, leftIndex, middle - 1, item);
            }

            return Search(items, middle + 1, rightIndex, item);
        }
        
        static void Main(string[] args)
        {
            var items = new List<int> {1, 2, 5, 7, 8, 10, 14, 17, 20, 32, 56, 64};
            int rightIndex = items.Count - 1;
            int leftIndex = 0;
            Console.WriteLine(Search(items, 0, items.Count - 1, 14));
            
        }
    }
}
