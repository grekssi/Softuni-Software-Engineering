using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CollectionHier
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> collection;
        public List<string> Collection => this.collection;

        public AddRemoveCollection()
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
            var removed = collection[this.collection.Count - 1];
            collection.RemoveAt(this.collection.Count- 1);
            return removed;
        }
    }
}
