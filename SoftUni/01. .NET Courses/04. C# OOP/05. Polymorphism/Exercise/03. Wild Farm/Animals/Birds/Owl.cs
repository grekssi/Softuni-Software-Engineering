using System.Collections.Generic;

namespace WildLife.Animals.Birds
{
    public class Owl : Bird
    {
        private List<string> edibles = new List<string>()
        {
            "Meat"
        };
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override List<string> Edibles => this.edibles;

        public override void Feed(int amount)
        {
            base.Weight += 0.25 * amount;
        }
    }
}
