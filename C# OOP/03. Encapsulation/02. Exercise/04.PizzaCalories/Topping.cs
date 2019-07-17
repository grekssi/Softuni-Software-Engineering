using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, decimal> typeToppings = new Dictionary<string, decimal>()
        {
            {"meat", 1.2m},
            {"veggies", 0.8m},
            {"cheese", 1.1m},
            {"sauce", 0.9m},
        };

        private string topping;
        private decimal weight;

        public Topping(string topping, decimal weight) //might break if not given decimal WARNING!
        {
            this.ToppingP = topping;
            this.Weight = weight;
        }

        public string ToppingP
        {
            get => this.topping;
            private set
            {
                if (!typeToppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.topping = value;
            }
        }

        public decimal Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.topping} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public decimal GetCalories()
        {
            return 2 * this.Weight * typeToppings[topping.ToLower()];
        }
    }
}
