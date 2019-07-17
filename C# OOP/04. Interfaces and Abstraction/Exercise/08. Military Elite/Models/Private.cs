using System.Text;
using MilitaryElite2.Interfaces;

namespace MilitaryElite2.Models
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public decimal Salary
        {
            get => this.salary;
            private set => this.salary = value; 
        }
        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {this.Salary:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
