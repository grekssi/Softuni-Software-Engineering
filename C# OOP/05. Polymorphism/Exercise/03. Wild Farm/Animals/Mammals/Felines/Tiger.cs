using System.Collections.Generic;

namespace WildLife.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private List<string> edibles = new List<string>()
        {
            "Meat"
        };
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override List<string> Edibles => this.edibles;

        public override void Feed(int amount)
        {
            base.Weight += 1.00 * amount;
        }
    }
}
