using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionH
{
    class Citizen : IPerson, IResident
    {
        public string Name { get; set; }

        public Citizen(string name)
        {
            this.Name = name;
        }

        string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

    }
}
