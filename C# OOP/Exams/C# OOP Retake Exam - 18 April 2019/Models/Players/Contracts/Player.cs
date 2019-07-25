using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Contracts
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private bool isDead;

        public ICardRepository CardRepository { get; set; }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Player's username cannot be null or an empty string. ");
                }
                
                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Player's health bonus cannot be less than zero. ");
                }

                this.health = value;
            }
        }
        public bool IsDead { get; set; }
        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (this.Health - damagePoints >= 0)
            {
                this.Health -= damagePoints;
            }
            else
            {
                this.Health = 0;
                this.IsDead = true;
            }   
        }

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

    }
}
