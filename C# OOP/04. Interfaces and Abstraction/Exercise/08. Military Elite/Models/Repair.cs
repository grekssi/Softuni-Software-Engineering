using System.Text;
using MilitaryElite2.Interfaces;

namespace MilitaryElite2.Models
{
    public class Repair : IRepair
    {
        private string partName;
        private int hoursWorked;
        public string PartName { get; }
        public int HoursWorker { get; }

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorker = hoursWorked;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Part Name: {this.PartName} Hours Worked: {this.HoursWorker}");
            return sb.ToString().Trim();
        }
    }
}
