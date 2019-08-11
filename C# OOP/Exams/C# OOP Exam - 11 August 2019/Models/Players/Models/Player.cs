using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;
using ViceCity.Repositories.Models;

namespace ViceCity.Models.Players.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private bool isAlive = true;
        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.NullName));
                }

                this.name = value;
            }
        }

        public bool IsAlive
        {
            get => this.isAlive;
            private set => this.isAlive = value;
        }
        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }

                this.lifePoints = value;
            }
        }
        public void TakeLifePoints(int points)
        {
            int result = this.lifePoints - points;
            if (result <= 0)
            {
                this.lifePoints = 0;
                this.IsAlive = false;
            }
            else
            {
                this.lifePoints -= points;
            }
        }
    }
}
