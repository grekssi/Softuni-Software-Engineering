using System;
using System.Text;

namespace tuplegenerics
{
    class Tuple<T, U>
    {
        public T item1 { get; private set; }
        public U item2 { get; private set; }

        public Tuple(T item1, U item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }
    }
}
