using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Cargo
    {
        public int weight { get; private set; }
        public string type { get; private set; }

        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }
    }
}
