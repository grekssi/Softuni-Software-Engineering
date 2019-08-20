using System;
using System.Collections.Generic;
using System.Text;

namespace WildLife.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private List<string> edibles = new List<string>()
        {
            "Vegetable",
            "Fruit"
        };

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override List<string> Edibles => this.edibles;

        public override void Feed(int amount)
        {
            base.Weight += 0.10 * amount;
        }
    }
}
