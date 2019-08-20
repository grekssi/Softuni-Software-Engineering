using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PizzaCalories
{
    public class Dough
    {
        // • White – 1.5;
        // • Wholegrain – 1.0;
        // • Crispy – 0.9;
        // • Chewy – 1.1;
        // • Homemade – 1.0;
        
        private Dictionary<string, decimal> doughs = new Dictionary<string, decimal>()
        {
            {"white", 1.5m},
            {"wholegrain", 1.0m},
        };

        private Dictionary<string, decimal> bakings = new Dictionary<string, decimal>()
        {
            {"crispy", 0.9m},
            {"chewy", 1.1m},
            {"homemade", 1.0m},
        };

        private string flourType;
        private string bakingTechnique;
        private decimal weight;

        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!this.doughs.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!bakings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }


        public decimal Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public decimal GetCalories()
        {
            decimal totalCalories = this.Weight * 2 * doughs[this.FlourType.ToLower()] * bakings[this.BakingTechnique.ToLower()];
            return totalCalories;
        }
    }
}
