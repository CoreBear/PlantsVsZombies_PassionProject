using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class CherryBomb : Plant
    {
        bool exploded;
        int bombClock;
        int timeForExplosion;
        int timeForDeath;

        public CherryBomb()
        {
            maxHealth = 100;
            exploded = false;
            timeForDeath = 3000;
            timeForExplosion = 5000;
            plantPrice = 150;
            typeOfPlant = (int)PlantTypes.CherryBomb;
            sprite = new string[8] {"       ww      ", "       \\/      ", "      //\\\\     ", "     // _\\\\_   ",
                                    "   _||_/   o\\  ", "  /o    \\o / | ", " | \\ o  |___/  ", "  \\____/       " };

            //"       ww      ",
            //"       \\/      ",
            //"      //\\\\     ",
            //"     // _\\\\_   ",
            //"   _||_/   o\\  ",
            //"  /o    \\o / | ",
            //" | \\ o  |___/  ",
            //"  \\____/      ",
            StartTimer();
        }
        void StartTimer()
        {
            bombClock = (int)Program.GetGameClock().ElapsedMilliseconds;
        }
        public override void Update()
        {
            Explode();
            Kill();
            EndLife();
        }
        public override void Render()
        {
            if (!exploded)
            {
                for (int i = 0; i < sprite.Length; i++)
                {
                    Tools.EasyWriter((int)xPosition, (int)yPosition + i, sprite[i]);
                }
            }
        }
        void Explode()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > bombClock + timeForExplosion && !exploded)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                RenderExplosionAndClear();
                Console.BackgroundColor = ConsoleColor.Black;
                bombClock = (int)Program.GetGameClock().ElapsedMilliseconds;
                exploded = true;
            }
        }
        void Kill()
        {
            if (exploded)
            {
                foreach (var zombie in ObjectPooler.GetZombies())
                {
                    if (((int)zombie.GetX() > (int)xPosition - 27 && (int)zombie.GetX() < (int)xPosition + 34) &&
                        ((int)zombie.GetY() > (int)yPosition - 10 && (int)zombie.GetY() < (int)yPosition + 10))
                    {
                        zombie.Death();
                    }
                }
            }
        }
        void EndLife()
        {
            if (exploded)
            {
                if ((int)Program.GetGameClock().ElapsedMilliseconds > bombClock + timeForDeath)
                {
                    RenderExplosionAndClear();
                    Death();
                }
            }
            
        }
        void RenderExplosionAndClear()
        {
            for (int y = 0; y < 26; y++)
            {
                for (int x = 0; x < 59; x++)
                {
                    if (y == 8 || y == 17)
                        continue;

                    if (((int)xPosition != 21 && (int)xPosition != 201) && ((int)yPosition != 6 && (int)yPosition != 51))
                    {
                        Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition - 9) + y, " ");
                    }
                    else if ((int)xPosition == 21)
                    {
                        if ((int)yPosition != 6 && (int)yPosition != 51)
                        {
                            if (x < 39)
                                Tools.EasyWriter(((int)xPosition - 2) + x, ((int)yPosition - 9) + y, " ");
                        }
                        else if ((int)yPosition == 51)
                        {
                            if (x < 39 && y < 17)
                                Tools.EasyWriter(((int)xPosition - 2) + x, ((int)yPosition - 9) + y, " ");
                        }
                    }
                    else if ((int)yPosition == 6)
                    {
                        if ((int)xPosition != 21 && (int)xPosition != 201)
                        {
                            if (y < 17)
                                Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition) + y, " ");
                        }
                        else if ((int)xPosition == 201)
                        {
                            if (x < 39 && y < 17)
                                Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition) + y, " ");
                        }
                    }
                    else if ((int)yPosition == 51)
                    {
                        if ((int)xPosition != 21 && (int)xPosition != 201)
                        {
                            if (y < 17)
                                Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition - 9) + y, " ");
                        }
                        else if ((int)xPosition == 21)
                        {
                            if (x < 39 && y < 17)
                                Tools.EasyWriter(((int)xPosition - 2) + x, ((int)yPosition - 9) + y, " ");
                        }
                        else if ((int)xPosition == 201)
                        {
                            if (x < 39 && y < 17)
                                Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition - 9) + y, " ");
                        }
                    }
                    else if ((int)xPosition == 201)
                    {
                        if ((int)yPosition != 6 && (int)yPosition != 51)
                        {
                            if (x < 39)
                                Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition - 9) + y, " ");
                        }
                        else if ((int)yPosition == 6)
                        {
                            if (x < 39 && y < 17)
                                Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition) + y, " ");
                        }
                        else if ((int)yPosition == 51)
                        {
                            if (x < 39 && y < 17)
                                Tools.EasyWriter(((int)xPosition - 22) + x, ((int)yPosition - 9) + y, " ");
                        }
                    }
                }
            }
        }
    }
}
