using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class PeaProjectile : Projectile
    {
        public PeaProjectile()
        {
            speed = 2.00f;
            sprite = new string[1] {"O"};
            damage = 25;
        }
    }
}
