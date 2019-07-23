using System;
using System.Collections.Generic;
using System.Text;

namespace WildLife.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public string LivingRegion { get; protected set; }
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
