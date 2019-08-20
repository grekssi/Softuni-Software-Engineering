using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ViceCity.Models.Guns.Models
{
    class Pistol : Gun
    {
        private const int InitialBPB = 10;
        private const int InitialTotalBullets = 100;
        public Pistol(string name) 
            : base(name, InitialBPB, InitialTotalBullets)
        {
            base.bullets = InitialBPB; //may not be loaded at first
        }

        public override int Fire()
        {
            if (base.bullets - 1 < 0)
            {
                if (base.totalBullets - base.bulletsPerBarrel < 0)
                {
                    base.canfire = false;
                    return 0;
                }
                else
                {
                    base.bullets += base.BulletsPerBarrel;
                    base.totalBullets -= base.BulletsPerBarrel;
                    base.bullets -= 1;
                    return 1;
                }
                

            }
            else
            {
                base.bullets -= 1;
                return 1;
            }
        }
    }
}
