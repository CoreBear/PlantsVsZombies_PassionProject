using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class PeaShooter : ShootingPlant
    {
        public PeaShooter()
        {
            plantPrice = 100;
            typeOfPlant = (int)PlantTypes.PeaShooter;
            timeBetweenShots = 5000;
            maxHealth = 100;
            sprite = new string[8] {"  _______  __  ", " /    o o\\/ /\\ ", "~|          | |", " \\_______/\\_\\/ ",
                                    "    \\  /       ", "     ||        ", "   mm||mm      ", " MMMMMMMMMM    " };
            //string[] sprites = new string[8] {
            //"   _______  __  ",
            //"  /    o o\\/ /\\ ",
            //"~|          |   |",
            //"  \\_______/\\_\\/ ",
            //"     \\  /       ",
            //"      ||        ",
            //"    mm||mm      ",
            //"  MMMMMMMMMM    " };

        }
    }
}
