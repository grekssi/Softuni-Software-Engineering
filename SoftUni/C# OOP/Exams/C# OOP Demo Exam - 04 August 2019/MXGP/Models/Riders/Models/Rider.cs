using System;
using System.Collections.Generic;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Riders.Models
{
    public class Rider : IRider
    {
        private string name;
        private bool canParticipate = false;
        public Rider(string name)
        {
            this.Name = name;
            this.NumberOfWins = 0;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }
        public IMotorcycle Motorcycle { get; private set; }
        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => this.canParticipate;
            private set => this.canParticipate = value;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            this.Motorcycle = motorcycle ?? throw new ArgumentNullException(string.Format(ExceptionMessages.MotorcycleInvalid));
            this.canParticipate = true;
        }
    }
}
