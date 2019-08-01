using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;
        protected Food(string name, int servingSize, decimal price)
        {
            
        }

        public string Name { get; }
        public int ServingSize { get; }
        public decimal Price { get; }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.price:F2}";
        }
    }
}
