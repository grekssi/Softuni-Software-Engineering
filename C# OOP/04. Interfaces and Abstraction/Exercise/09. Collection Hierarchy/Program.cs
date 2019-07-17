using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHier
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> result = new List<int>();
            var toAdd = Console.ReadLine().Split(' ').ToArray();
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in toAdd)
                {
                    switch (i)
                    {
                        case 0:
                            result.Add(addCollection.Add(item));
                            break;
                        case 1:
                            result.Add(addRemoveCollection.Add(item));
                            break;
                        case 2:
                            result.Add(myList.Add(item));
                            break;
                    }
                }

                Console.WriteLine(string.Join(" ", result));
                result.Clear();
            }
            var result2 = new List<string>();
            int toRemove = int.Parse(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < toRemove; j++)
                {
                    switch (i)
                    {
                        case 0:
                            result2.Add(addRemoveCollection.Remove());
                            break;
                        case 1:
                            result2.Add(myList.Remove());
                            break;
                    }
                }

                Console.WriteLine(string.Join(" ", result2));
                result2.Clear();
            }

        }
    }
}
