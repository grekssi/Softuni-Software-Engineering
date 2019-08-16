using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HealthyHeaven
{
    class Vegetable
    {
        private string name;
        private int calories;

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Calories
        {
            get { return this.calories; }
            private set { this.calories = value; }
        }

        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }

        public override string ToString()
        {
            var sbu = new StringBuilder();
            sbu.AppendLine($" - {this.Name} have {this.Calories} calories");
            return sbu.ToString().TrimEnd();
        }
    }
}
