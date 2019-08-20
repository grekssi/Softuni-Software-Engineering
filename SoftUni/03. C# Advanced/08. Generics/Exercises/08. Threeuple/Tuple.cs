using System;
using System.Text;

namespace tuplegenerics
{
    class Tuple<T, U, Y>
    {
        public T item1 { get; private set; }
        public U item2 { get; private set; }
        public Y item3 { get; private set; }

        public Tuple(T item1, U item2, Y item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }
    }
}
