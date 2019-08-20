using System.Collections.Generic;

namespace WildLife.Animals.Birds
{
    class Hen : Bird
    {
        private List<string> edibles = new List<string>()
        {
            "Meat",
            "Vegetable",
            "Seed",
            "Fruit"
        };
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }
        public override List<string> Edibles => this.edibles;

        public override void Feed(int amount)
        {
            base.Weight += 0.35 * amount;
        }
    }
}
