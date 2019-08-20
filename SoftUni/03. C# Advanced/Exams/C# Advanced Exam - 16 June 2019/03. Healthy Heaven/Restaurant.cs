using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace HealthyHeaven
{
    class Restaurant
    {
        public List<Salad> data;
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)  //may need to remove
        {
            if (this.data.Select(x => x.Name).Contains(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Salad GetHealthiestSalad()
        {
            return data.OrderBy(x => x.Products.Sum(z => z.Calories)).FirstOrDefault();
        }

        public string GenerateMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.name} have {this.data.Count()} salads:");
            foreach (var salad in data)
            {

                sb.AppendLine(string.Join(Environment.NewLine, salad));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
