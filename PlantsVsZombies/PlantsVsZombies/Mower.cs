using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class Mower : OnScreenObject
    {
        bool waiting;
        bool enabled;
        float speed;
        int timeBetweenZombieCheck;
        int currentZombieCheckTime;
        int timeBetweenCollisionCheck;
        int currentCollisionCheckTime;

        public Mower()
        {
            timeBetweenZombieCheck = 250;
            timeBetweenCollisionCheck = 125;
            currentZombieCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
            currentCollisionCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
            enabled = false;
            waiting = true;
            speed = 3.00f;
            sprite = new string[8]{ "  __             ", " //\\\\            ", "//  \\\\           ", "\\\\  //\\          ", " \\\\// \\\\    __   ", "  \\\\   \\\\__/  \\__", "   \\\\__/___|__|_/", "    O          O " };

            //"  __             ",
            //" //\\\\            ",
            //"//  \\\\           ",
            //"\\\\  //\\          ",
            //" \\\\// \\\\    __   ",
            //"  \\\\   \\\\__/  \\__",
            //"   \\\\__/___|__|_/",
            //"    O          O "
        }
        public void Update()
        {
            Move();
            Collision();
            CheckForZombie();
        }
        void Move()
        {
            if (enabled)
            {
                if ((int)xPosition > Console.WindowWidth - 18)
                {
                    SetWaiting(false);
                    SetEnabled(false);
                    ObjectPooler.GetMowers().Remove(this);
                }
                ClearPreviousRender("                   ");
                xPosition += speed;
            }
        }
        void Collision()
        {
            if (enabled)
            {
                if ((int)Program.GetGameClock().ElapsedMilliseconds > currentCollisionCheckTime + timeBetweenCollisionCheck)
                {
                    foreach (var zombie in ObjectPooler.GetZombies())
                    {
                        if (zombie.GetEnabled())
                        {
                            if ((int)xPosition >= (int)zombie.GetX() - 2 && (int)yPosition == (int)zombie.GetY())
                            {
                                zombie.TakeDamage(zombie.GetMaxHealth());
                            }
                        }
                    }
                    currentCollisionCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
                }
            }
        }
        void CheckForZombie()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > currentZombieCheckTime + timeBetweenZombieCheck)
            {
                foreach (var zombie in ObjectPooler.GetZombies())
                {
                    if (zombie.GetEnabled())
                    {
                        if ((int)zombie.GetX() < (int)xPosition + 19 && (int)zombie.GetY() == (int)yPosition)
                        {
                            SetEnabled(true);
                            break;
                        }
                    }
                }
                currentZombieCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
            }
        }

        //Getters
        public bool GetEnabled()
        {
            return enabled;
        }
        public bool GetWaiting()
        {
            return waiting;
        }

        //Setters
        public void SetEnabled(bool enable)
        {
            enabled = enable;
        }
        public void SetWaiting(bool wait)
        {
            waiting = wait;
        }
    }
}
