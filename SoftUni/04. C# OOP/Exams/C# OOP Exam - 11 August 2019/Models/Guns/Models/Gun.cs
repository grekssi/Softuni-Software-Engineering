using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns.Models
{
    public abstract class Gun : IGun
    {
        private string name;
        protected int totalBullets;
        protected int bulletsPerBarrel; //barrel
        protected int bullets;
        protected bool canfire = true;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }

                this.name = value;
            }
        }
        //o	The initial BulletsPerBarrel count is the actual capacity of the barrel!
        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire
        {
            get => this.canfire;
            protected set { this.canfire = value; }
        }
        public abstract int Fire();

    }
}
