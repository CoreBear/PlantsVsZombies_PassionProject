using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class Projectile : OnScreenObject
    {
        protected bool enabled;
        protected float speed;
        protected int damage;
        protected int timeBetweenCollisionChecks;
        protected int currentCheckTime;

        public Projectile()
        {
            enabled = false;
            timeBetweenCollisionChecks = 125;
            currentCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
        }
        public virtual void Update()
        {
            Collision();
            EdgeOfScreen();
            Move();
        }
        void Collision()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > currentCheckTime + timeBetweenCollisionChecks)
            {
                foreach (var zombie in ObjectPooler.GetZombies())
                {
                    if (zombie.GetEnabled())
                    {
                        if ((int)xPosition >= (int)zombie.GetX() - 2 && ((int)yPosition > (int)zombie.GetY() && (int)yPosition < (int)zombie.GetY() + 8))
                        {
                            zombie.TakeDamage(damage);
                            SetEnabled(false);
                        }
                    }
                }
                currentCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
            }
        }
        void EdgeOfScreen()
        {
            if ((int)xPosition > Console.WindowWidth - 3)
                SetEnabled(false);
        }
        void Move()
        {
            ClearPreviousRender(" ");
            xPosition += speed;
        }

        //Getters
        public bool GetEnabled()
        {
            return enabled;
        }

        //Setters
        public void SetEnabled(bool enable)
        {
            enabled = enable;
        }
    }
}
