using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MilitaryElite2.Interfaces;

namespace MilitaryElite2.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<Private> privates;
        public IReadOnlyCollection<Private> Privates => this.privates.AsReadOnly();
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        public void AddPrivate(Private privateToAdd)
        {
            this.privates.Add(privateToAdd);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:f2}");
            sb.AppendLine($"Privates:");
            foreach (var @private in Privates)
            {
                sb.AppendLine($"  {@private.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
