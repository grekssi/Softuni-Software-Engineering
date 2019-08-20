using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length > 15 || value.Length < 1 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            private set => this.dough = value;
        }

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public void AddDough(Dough dough)
        {
            this.Dough = dough;
        }

        public void Add(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public decimal GetTotalCalories()
        {
            return this.Dough.GetCalories() + this.toppings.Sum(x => x.GetCalories());
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():f2} Calories.";
        }
    }
}
