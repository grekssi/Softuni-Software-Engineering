using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite2.Interfaces;

namespace MilitaryElite2.Models
{
    class Engineer : SpecialisedSoldier, IEngineer

    {
        private readonly List<Repair> reparis;
        public IReadOnlyCollection<IRepair> Repairs => this.reparis.AsReadOnly();
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.reparis = new List<Repair>();
        }

        public void AddRepair(Repair repair)
        {
            this.reparis.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:f2}");
            sb.AppendLine($"Corps: {base.Corps}");
            sb.AppendLine($"Repairs:"); //might not need to print if list is 0
            foreach (var repair in reparis)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
