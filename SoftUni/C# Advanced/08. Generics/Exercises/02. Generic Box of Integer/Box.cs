using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace GenericsBoxOfStrings
{
    public class Box<T>
    {
        public static List<T> mylist;

        public Box()
        {
            mylist = new List<T>();
        }

        public void Add(T item)
        {
            mylist.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in mylist)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
