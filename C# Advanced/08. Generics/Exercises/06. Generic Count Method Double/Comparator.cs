using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics4
{
    class Comparator<T>
    {
        public List<T> data = new List<T>();

        public void Add(T item)
        {
            data.Add(item);
        }
    }
}
