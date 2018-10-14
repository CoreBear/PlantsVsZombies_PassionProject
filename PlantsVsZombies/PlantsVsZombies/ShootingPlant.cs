using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class ShootingPlant : Plant
    {
        protected int currentClockForShot;
        protected int timeBetweenShots;

        public ShootingPlant()
        {
            currentClockForShot = (int)Program.GetGameClock().ElapsedMilliseconds;            
        }
        public override void Update()
        {
            Shoot();
        }
        void Shoot()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > currentClockForShot + timeBetweenShots)
            {
                if (GameBoard.GetRowInUseByZombie()[inRow])
                {
                    ObjectSpawner.SpawnProjectile(xPosition, yPosition);
                }                
                currentClockForShot = (int)Program.GetGameClock().ElapsedMilliseconds;
            }
        } 
    }
}
