using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns.Models
{
    public class Rifle : Gun
    {
        private const int InitialBPB = 50;
        private const int InitialTotalBullets = 500;
        public Rifle(string name)
            : base(name, InitialBPB, InitialTotalBullets)
        {
            base.bullets = InitialBPB;
        }

        public override int Fire()
        {
            if (base.bullets - 5 < 0) 
            {
                if (base.TotalBullets - base.BulletsPerBarrel < 0)
                {
                    base.canfire = false;
                    return 0;
                }
                else
                {
                    base.bullets += base.BulletsPerBarrel;
                    base.totalBullets -= base.BulletsPerBarrel;
                    base.bullets -= 5;
                    return 5; //here as well
                }
            }
            else
            {
                base.bullets -= 5;
                return 5;
            }
        }
    }
}
