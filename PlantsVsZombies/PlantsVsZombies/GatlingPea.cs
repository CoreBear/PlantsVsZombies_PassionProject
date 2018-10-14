using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class GatlingPea : PeaShooter
    {
        public GatlingPea()
        {
            plantPrice = 250;
            typeOfPlant = (int)PlantTypes.GatlingPea;
            timeBetweenShots = 100;
            maxHealth = 100;
            sprite = new string[8]{"   ________    _   ", "  /     ___\\__/ \\  ", " |    _/O O   |====", " |   /\\\\     _   |  ",
                               "  \\_/__\\\\___/ \\_/  ", "       \\||/        ", "      mm||mm       ", "    MMMMMMMMMM     " };
            //"   ________    _   ",
            //"  /     ___\\__/ \\  ",
            //" |    _/O O   |====",
            //" |   /\\\\     _     ",
            //"  \\_/__\\\\___/ \\_/  ",
            //"       \\||/        ",
            //"      mm||mm       ",
            //"    MMMMMMMMMM     ",
        }
    }
}
