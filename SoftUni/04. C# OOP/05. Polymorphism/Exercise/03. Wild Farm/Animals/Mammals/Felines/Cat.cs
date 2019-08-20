using System.Collections.Generic;

namespace WildLife.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private List<string> edibles = new List<string>()
        {
            "Vegetable",
            "Meat"
        };
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override List<string> Edibles => this.edibles;

        public override void Feed(int amount)
        {
            base.Weight += 0.30 * amount;
        }
    }
}
