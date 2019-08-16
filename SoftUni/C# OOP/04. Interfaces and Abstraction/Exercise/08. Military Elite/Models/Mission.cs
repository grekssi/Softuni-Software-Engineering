using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MilitaryElite2.Interfaces;

namespace MilitaryElite2.Models
{
    public class Mission : IMission
    {
        private readonly string[] possibleStates = new string[] { "inProgress", "Finished" };
        private string codeName;
        private string state;

        public string CodeName
        {
            get => this.codeName;
            private set => this.codeName = value;
        }

        public string State
        {
            get => this.state;
            private set
            {
                if (!this.possibleStates.Contains(value))
                {
                    throw new ArgumentException("invalid state");
                }

                this.state = value;
            }
        }

        public Mission(string codeName, string stage)
        {
            this.CodeName = codeName;
            this.State = stage;
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Code Name: {this.CodeName} State: {this.State}");
            return sb.ToString().TrimEnd();
        }
    }
}
