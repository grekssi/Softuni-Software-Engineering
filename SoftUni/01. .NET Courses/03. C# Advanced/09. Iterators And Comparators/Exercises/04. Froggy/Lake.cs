using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    class Lake<T> : IEnumerable<T>, IComparer<T>
    {
        private List<T> items;

        public Lake(params T[] elements)
        {
            items = new List<T>(elements);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return items[i];
                }
            }
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return items[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


        public int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }
    }
}
