using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    class Salad
    {
        private List<Vegetable> products;
        private string name;

        public List<Vegetable> Products
        {
            get { return this.products; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return this.products.Sum(x => x.Calories);
        }

        public int GetProductCount()
        {
            return this.products.Count();
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"* Salad {name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");
            sb.AppendLine(string.Join(Environment.NewLine, products));
            return sb.ToString().TrimEnd();
        }
    }
}
