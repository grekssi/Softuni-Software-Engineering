using System;
using System.Collections.Generic;
using System.Text;

namespace Generics3
{
    public class Swapper<T>
    {
        /// <summary>
        /// Adds item to a list and then swaps two given indexes
        /// </summary>

        public static List<T> data = new List<T>();

        public void Add(T item)
        {
            data.Add(item);
        }

        public void Swap(int index1, int index2)
        {
            var keepData1 = data[index1];
            var keepData2 = data[index2];
            data[index2] = keepData1;
            data[index1] = keepData2;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
