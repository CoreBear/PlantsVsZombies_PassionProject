using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class WallNut : Plant
    {
        public WallNut()
        {
            maxHealth = 200;
            plantPrice = 50;
            typeOfPlant = (int)PlantTypes.WallNut;
            sprite = new string[8]{ "   _________   ", "  / /       \\  ", " / /( )  ( ) \\ ", "/ /     __    |",
                                    "| |           |", "| |           |", "| |           |", " \\_\\_________/ "};
            
            //"   _________   ",
            //"  / /       \\  ",
            //" / /( )  ( ) \\ ",
            //"/ /     __    |",
            //"| |           |",
            //"| |           |",
            //"| |           |",
            //" \\_\\_________/ "            
        }
    }
}
