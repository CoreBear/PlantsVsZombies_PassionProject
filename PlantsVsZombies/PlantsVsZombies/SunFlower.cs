using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class SunFlower : Plant
    {
        protected int currentClockForSun;
        protected int timeBetweenSun;

        public SunFlower()
        {
            plantPrice = 50;
            currentClockForSun = (int)Program.GetGameClock().ElapsedMilliseconds;
            timeBetweenSun = 7000;
            typeOfPlant = (int)PlantTypes.SunFlower;
            maxHealth = 100;
            sprite = new string[8] { "   wwwwwwww    ", "  3        E   ", " 3    O  O  E  ", "  3 \\_____/E   ",
                                     "   MMMMMMMM    ", "      ||       ", "    mm||mm     ", "  MMMMMMMMMM   " };

            //"  wwwwwwww  ",
            //" 3        E ",
            //"3    O  O  E",
            //" 3 \\_____/E ",
            //"  MMMMMMMM  ", 
            //"     ||     ",
            //"   mm||mm   ",
            //" MMMMMMMMMM ",
        }
        public override void Update()
        {
            DropSun();
        }
        void DropSun()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > currentClockForSun + timeBetweenSun)
            {
                ObjectSpawner.SpawnSun(xPosition, yPosition);
                currentClockForSun = (int)Program.GetGameClock().ElapsedMilliseconds;
            }
        }
    }
}
