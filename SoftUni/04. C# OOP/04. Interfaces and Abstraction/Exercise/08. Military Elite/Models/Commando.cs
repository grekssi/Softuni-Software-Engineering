using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MilitaryElite2.Interfaces;

namespace MilitaryElite2.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<Mission> missions;
        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
        }

        public void AddMission(Mission mission)
        {
            if (this.missions.Any(m => m.CodeName == mission.CodeName))
            {
                int index = this.missions.FindIndex(m => m.CodeName == mission.CodeName);
                this.missions[index].CompleteMission();
            }
            else
            {
                if (mission.State != null)
                {
                    this.missions.Add(mission);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:f2}");
            sb.AppendLine($"Corps: {base.Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
