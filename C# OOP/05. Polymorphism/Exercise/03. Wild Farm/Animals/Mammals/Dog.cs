using System.Collections.Generic;

namespace WildLife.Animals.Mammals
{
    public class Dog : Mammal
    {
        private List<string> edibles = new List<string>()
        {
            "Meat"
        };
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        public override List<string> Edibles => this.edibles;
        public override void Feed(int amount)
        {
            base.Weight += 0.40 * amount;
        }
    }
}
