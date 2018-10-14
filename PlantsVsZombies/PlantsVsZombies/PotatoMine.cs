using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class PotatoMine : Plant
    {

        bool exploded;
        int bombClock;
        int timeForcheck;
        int timeForDeath;

        public PotatoMine()
        {
            exploded = false;
            timeForDeath = 1000;
            timeForcheck = 250;
            bombClock = (int)Program.GetGameClock().ElapsedMilliseconds;
            plantPrice = 25;
            typeOfPlant = (int)PlantTypes.PotatoMine;
            sprite = new string[8] {"               ", "               ", "       __      ", "      (  )     ",
                                    " ______||____  ", "/   ( )  ( ) \\ ", " O     --    O ", "  OoOoOoOoOoO  " };

            //"               ",
            //"               ",
            //"       __      ",
            //"      (  )     ",
            //" ______||____  ",
            //"/   ( )  ( ) \\ ",
            //" O     --    O ",
            //"  OoOoOoOoOoO  ", 
        }
        public override void Update()
        {
            Explode();
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
            if (((int)Program.GetGameClock().ElapsedMilliseconds > bombClock + timeForcheck) && !exploded)
            {
                foreach (var zombie in ObjectPooler.GetZombies())
                {
                    if (zombie.GetEnabled())
                    {
                        if (zombie.GetX() < xPosition + 13 && zombie.GetY() == yPosition)
                        {
                            zombie.Death();
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            RenderExplosionAndClear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            bombClock = (int)Program.GetGameClock().ElapsedMilliseconds;
                            exploded = true;
                            break;
                        }
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
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 19; x++)
                {
                        Tools.EasyWriter(((int)xPosition - 2) + x, ((int)yPosition) + y, " ");
                }
            }
        }
    }
}

