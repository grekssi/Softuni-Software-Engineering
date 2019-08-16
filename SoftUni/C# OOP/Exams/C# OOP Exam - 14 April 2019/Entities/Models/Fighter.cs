using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        private const double InitialAttackPoints = 50;
        private const double InitialDefensePoints = 25; 
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints + InitialAttackPoints,
                defensePoints - InitialDefensePoints,
                InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }
        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                this.AggressiveMode = false;
                base.AttackPoints -= InitialAttackPoints;
                base.DefensePoints += InitialDefensePoints;
            }
            else
            {
                this.AggressiveMode = true;
                base.AttackPoints += InitialAttackPoints;
                base.DefensePoints -= InitialDefensePoints;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(" *Aggressive: ");
            sb.AppendLine(AggressiveMode == true ? "ON" : "OFF");
            return sb.ToString().TrimEnd();
        }
    }
}
