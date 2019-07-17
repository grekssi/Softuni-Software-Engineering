using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CollectionHier
{
    public class MyList : IMyList
    {
        private readonly List<string> collection;
        public List<string> Collection => this.collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            var removed = collection[0];
            collection.RemoveAt(0);
            return removed;
        }
    }
}
