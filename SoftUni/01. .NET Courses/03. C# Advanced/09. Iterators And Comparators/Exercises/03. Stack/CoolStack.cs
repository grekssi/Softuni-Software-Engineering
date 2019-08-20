using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Stack
{
    public class CoolStack<T> : IEnumerable<T>
    {
        private List<T> elements = new List<T>();

        public void Push(T item)
        {
            elements.Add(item);
        }

        public void Pop()
        {
            try
            {
                T removed = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"No elements");
            }
        }

        //public T Peek()
        //{
        //    return elements[elements.Count - 1];
        //}

        public int Count() => this.elements.Count;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
