using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class Jalapeno : Plant
    {
        bool exploded;
        int bombClock;
        int timeForExplosion;
        int timeForDeath;

        public Jalapeno()
        {
            exploded = false;
            timeForDeath = 1000;
            timeForExplosion = 3000;
            plantPrice = 125;
            typeOfPlant = (int)PlantTypes.Jalapeno;
            sprite = new string[8]{"  __r__        ", " /     \\       ", "| ( ) ( )      ", "|    ===|      ",
                                   " \\      |      ", "   \\     \\     ", "     \\    \\_/7 ", "       \\____/  " };
            //"  __r__        ",
            //" /     \\       ",
            //"| ( ) ( )      ",
            //"|    ===|      ",
            //" \\      |      ",
            //"   \\     \\     ",
            //"     \\    \\_/7 ",
            //"       \\____/  ",

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
            if (((int)Program.GetGameClock().ElapsedMilliseconds > bombClock + timeForExplosion) && !exploded)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                RenderExplosionAndClear();
                Console.BackgroundColor = ConsoleColor.Black;
                bombClock = (int)Program.GetGameClock().ElapsedMilliseconds;
                exploded = true;
            }
        }
        void RenderExplosionAndClear()
        {
            int incrementor;

            for (int y = 0; y < 8; y++)
            {
                incrementor = 0;

                for (int x = (int)xPosition - 2; x < Console.WindowWidth - 22; x++)
                {
                    Tools.EasyWriter(((int)xPosition - 2) + incrementor, ((int)yPosition) + y, " ");
                    incrementor++;
                }
            }
        }
        void Kill()
        {
            if (exploded)
            {
                foreach (var zombie in ObjectPooler.GetZombies())
                {
                    if (((int)zombie.GetX() > (int)xPosition && (int)zombie.GetX() < 218) && (int)zombie.GetY() == (int)yPosition)
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
    }
}