using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp233
{
    class ListyOperator<T> : IEnumerable<T>
    {
        private List<T> elements;

        private int index = 0;
        private int foreachIndex = -1;


        public ListyOperator(params T[] collection)
        {
            elements = new List<T>(collection);
        }

        public bool Move()
        {
            try
            {
                T a = elements[++index];
                return true;
            }
            catch (Exception e)
            {
                index--;
                return false;
            }
        }

        public void Print()
        {
            if (elements.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                try
                {
                    Console.WriteLine(elements[index]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }
            
        }

        public bool HasNext()
        {
            if (this.elements.Count - 1 == index)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                foreachIndex++;
                yield return elements[foreachIndex];
            }

            foreachIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
    }
}
