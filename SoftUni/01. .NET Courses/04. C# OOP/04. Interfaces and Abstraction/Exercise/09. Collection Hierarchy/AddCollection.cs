using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CollectionHier
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> collection;
        public List<string> Collection => this.collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.Collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
