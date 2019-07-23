using System.Collections.Generic;

namespace WildLife.Animals
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public abstract List<string> Edibles { get; }
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public double FoodEaten { get; set; }

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public abstract void Feed(int amount);
    }
}
